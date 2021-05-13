using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Domain.Aggregates.TenantAggregate;
using ZeroStack.DeviceCenter.Domain.Entities;
using ZeroStack.DeviceCenter.Domain.UnitOfWork;

namespace ZeroStack.DeviceCenter.Infrastructure.EntityFrameworks
{
    public class DeviceCenterDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DeviceCenterDbContext(DbContextOptions<DeviceCenterDbContext> options) : base(options) => _mediator = this.GetInfrastructure().GetService<IMediator>() ?? new NullMediator();

        async Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken) => await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.IsAssignableTo(typeof(IMultiTenant)))
                {
                    ICurrentTenant currentTenant = this.GetService<ICurrentTenant>();
                    modelBuilder.Entity(entityType.ClrType).AddQueryFilter<IMultiTenant>(e => e.TenantId == currentTenant.Id);
                }

                if (entityType.ClrType.IsAssignableTo(typeof(ISoftDelete)))
                {
                    modelBuilder.Entity(entityType.ClrType).AddQueryFilter<ISoftDelete>(e => !e.IsDeleted);
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
