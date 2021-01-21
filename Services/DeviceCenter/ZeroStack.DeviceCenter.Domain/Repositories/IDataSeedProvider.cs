using System;
using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Domain.Repositories
{
    public interface IDataSeedProvider
    {
        Task SeedAsync(IServiceProvider serviceProvider);
    }
}
