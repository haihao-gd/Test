using System.Data;
using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Application.Queries.Factories
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnection(string? nameOrConnectionString = null);
    }
}
