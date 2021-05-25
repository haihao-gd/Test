using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using ZeroStack.DeviceCenter.Domain.Aggregates.PermissionAggregate;
using ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate;
using ZeroStack.DeviceCenter.Domain.Repositories;
using ZeroStack.DeviceCenter.Infrastructure.ConnectionStrings;
using ZeroStack.DeviceCenter.Infrastructure.Constants;
using ZeroStack.DeviceCenter.Infrastructure.EntityFrameworks;
using ZeroStack.DeviceCenter.Infrastructure.Repositories;

namespace ZeroStack.DeviceCenter.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConnectionStringProvider, TenantConnectionStringProvider>();

            services.AddEntityFrameworkSqlServer();

            services.AddDbContextPool<DeviceCenterDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(DbConstants.DefaultConnectionStringName), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });

                IMediator mediator = serviceProvider.GetService<IMediator>() ?? new NullMediator();
                optionsBuilder.AddInterceptors(new CustomSaveChangesInterceptor(mediator));

                var connectionStringProvider = serviceProvider.GetRequiredService<IConnectionStringProvider>();
                optionsBuilder.AddInterceptors(new TenantDbConnectionInterceptor(connectionStringProvider));

                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });

            services.AddPooledDbContextFactory<DeviceCenterDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(DbConstants.DefaultConnectionStringName), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });

                IMediator mediator = serviceProvider.GetService<IMediator>() ?? new NullMediator();
                optionsBuilder.AddInterceptors(new CustomSaveChangesInterceptor(mediator));

                var connectionStringProvider = serviceProvider.GetRequiredService<IConnectionStringProvider>();
                optionsBuilder.AddInterceptors(new TenantDbConnectionInterceptor(connectionStringProvider));

                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });

            services.AddTransient(typeof(IRepository<>), typeof(DeviceCenterEfCoreRepository<>));
            services.AddTransient(typeof(IRepository<,>), typeof(DeviceCenterEfCoreRepository<,>));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPermissionGrantRepository, PermissionGrantRepository>();

            return services;
        }
    }
}
