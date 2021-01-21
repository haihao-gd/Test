using System;

namespace ZeroStack.DeviceCenter.Infrastructure.EntityConfigurations.Tenants
{
    public interface ICurrentTenant
    {
        Guid? Id { get; }

        IDisposable Change(Guid? id);
    }
}
