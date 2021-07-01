using Dapper;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Models.Generics;
using ZeroStack.DeviceCenter.Application.Models.Projects;
using ZeroStack.DeviceCenter.Application.Queries.Factories;

namespace ZeroStack.DeviceCenter.Application.Queries.Projects
{
    public class ProjectQueries : IProjectQueries
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ProjectQueries(IDbConnectionFactory dbConnectionFactory) => _dbConnectionFactory = dbConnectionFactory;

        public async Task<ProjectGetResponseModel> GetProjectAsync(int id)
        {
            using var connection = await _dbConnectionFactory.CreateConnection();
            string sql = "SELECT TOP 1 * FROM [Projects] WHERE Id=@Id";
            var result = await connection.QueryFirstAsync<ProjectGetResponseModel>(sql, new { id });
            return result;
        }

        public async Task<PagedResponseModel<ProjectGetResponseModel>> GetProjectsAsync(ProjectPagedRequestModel model)
        {
            using IDbConnection connection = await _dbConnectionFactory.CreateConnection();

            string listSql = $"SELECT * FROM [Projects] WHERE [Name] LIKE @Keyword ORDER BY [ID] OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;";
            string countSql = $"SELECT COUNT(*) FROM [Projects] WHERE [Name] LIKE @Keyword";

            model.Keyword = $"%{model.Keyword}%";

            using var gridReader = await connection.QueryMultipleAsync(listSql + countSql, model);

            var list = await gridReader.ReadAsync<ProjectGetResponseModel>();
            int count = await gridReader.ReadSingleAsync<int>();
            list ??= Enumerable.Empty<ProjectGetResponseModel>();

            return new PagedResponseModel<ProjectGetResponseModel>(list.ToList(), count);
        }
    }
}
