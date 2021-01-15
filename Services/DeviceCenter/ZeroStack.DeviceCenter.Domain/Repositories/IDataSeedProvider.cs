using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Domain.Repositories
{
    public interface IDataSeedProvider
    {
        Task SeedAsync(IServiceProvider serviceProvider);
    }
}
