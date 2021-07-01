using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Models.Generics;
using ZeroStack.DeviceCenter.Application.Models.Projects;

namespace ZeroStack.DeviceCenter.Application.Queries.Projects
{
    public interface IProjectQueries
    {
        Task<ProjectGetResponseModel> GetProjectAsync(int id);

        Task<PagedResponseModel<ProjectGetResponseModel>> GetProjectsAsync(ProjectPagedRequestModel model);
    }
}
