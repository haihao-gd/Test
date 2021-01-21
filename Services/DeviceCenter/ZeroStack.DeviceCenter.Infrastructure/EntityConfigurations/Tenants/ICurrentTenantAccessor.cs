using System;

namespace ZeroStack.DeviceCenter.Infrastructure.EntityConfigurations.Tenants
{
    public interface ICurrentTenantAccessor
    {
        Guid? TenantId { get; set; }
    }
}
