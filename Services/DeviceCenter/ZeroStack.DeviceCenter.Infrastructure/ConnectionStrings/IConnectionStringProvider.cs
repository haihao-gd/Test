using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Infrastructure.ConnectionStrings
{
    public interface IConnectionStringProvider
    {
        Task<string> GetAsync(string? connectionStringName = null);
    }
}
