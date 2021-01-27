using System;

namespace ZeroStack.DeviceCenter.Domain.Aggregates.TenantAggregate
{
    public interface ICurrentTenantAccessor
    {
        Guid? TenantId { get; set; }
    }
}
