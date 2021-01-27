using System;

namespace ZeroStack.DeviceCenter.Domain.Aggregates.TenantAggregate
{
    public interface ICurrentTenant
    {
        Guid? Id { get; }

        IDisposable Change(Guid? id);
    }
}
