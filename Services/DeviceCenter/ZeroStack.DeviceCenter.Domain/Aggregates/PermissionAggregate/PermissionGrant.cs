using System;
using ZeroStack.DeviceCenter.Domain.Entities;

namespace ZeroStack.DeviceCenter.Domain.Aggregates.PermissionAggregate
{
    public class PermissionGrant : BaseAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public string Name { get; set; } = null!;

        public string ProviderName { get; set; } = null!;

        public string ProviderKey { get; set; } = null!;
    }
}
