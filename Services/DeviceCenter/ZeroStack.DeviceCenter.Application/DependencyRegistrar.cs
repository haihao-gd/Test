using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using ZeroStack.DeviceCenter.Application.Behaviors;
using ZeroStack.DeviceCenter.Application.Models.Generics;
using ZeroStack.DeviceCenter.Application.Models.Projects;
using ZeroStack.DeviceCenter.Application.Queries.Factories;
using ZeroStack.DeviceCenter.Application.Queries.Projects;
using ZeroStack.DeviceCenter.Application.Services.Generics;
using ZeroStack.DeviceCenter.Application.Services.Permissions;
using ZeroStack.DeviceCenter.Application.Services.Products;
using ZeroStack.DeviceCenter.Application.Services.Projects;

namespace ZeroStack.DeviceCenter.Application
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddDomainEvents();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddApplicationServices();
            services.AddAuthorization();

            services.AddQueries();

            ValidatorOptions.Global.LanguageManager = new Extensions.Validators.CustomLanguageManager();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection AddDomainEvents(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICrudApplicationService<int, ProjectGetResponseModel, PagedRequestModel, ProjectGetResponseModel, ProjectCreateOrUpdateRequestModel, ProjectCreateOrUpdateRequestModel>), typeof(ProjectApplicationService));

            services.AddTransient<IProductApplicationService, ProductApplicationService>();

            services.AddTransient<IPermissionApplicationService, PermissionApplicationService>();

            return services;
        }

        private static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache().AddTransient<IPermissionStore, PermissionStore>();
            services.AddTransient<IPermissionDefinitionManager, PermissionDefinitionManager>();

            var exportedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.ExportedTypes).Where(t => t.IsClass);

            var permissionDefinitionProviders = exportedTypes.Where(t => t.IsAssignableTo(typeof(IPermissionDefinitionProvider)));
            permissionDefinitionProviders.ToList().ForEach(t => services.AddSingleton(typeof(IPermissionDefinitionProvider), t));

            var permissionValueProviders = exportedTypes.Where(t => t.IsAssignableTo(typeof(IPermissionValueProvider)));
            permissionValueProviders.ToList().ForEach(t => services.AddTransient(typeof(IPermissionValueProvider), t));

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
            services.AddTransient<IProjectQueries, ProjectQueries>();

            return services;
        }
    }
}
