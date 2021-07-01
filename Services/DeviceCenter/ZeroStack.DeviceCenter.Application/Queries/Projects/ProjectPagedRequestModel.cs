using ZeroStack.DeviceCenter.Application.Models.Generics;

namespace ZeroStack.DeviceCenter.Application.Queries.Projects
{
    public class ProjectPagedRequestModel : PagedRequestModel
    {
        public string? Keyword { get; set; }
    }
}
