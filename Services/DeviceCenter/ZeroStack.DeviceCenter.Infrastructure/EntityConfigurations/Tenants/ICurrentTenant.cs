using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Infrastructure.EntityConfigurations.Tenants
{
    public interface ICurrentTenant
    {
        Guid? Id { get; }

        IDisposable Change(Guid? id);
    }
}
