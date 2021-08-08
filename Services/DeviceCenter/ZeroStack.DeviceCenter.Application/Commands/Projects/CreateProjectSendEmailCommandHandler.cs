using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Models.Projects;

namespace ZeroStack.DeviceCenter.Application.Commands.Projects
{
    public class CreateProjectSendEmailCommandHandler : IRequestHandler<CreateProjectCommand, ProjectGetResponseModel>
    {
        public async Task<ProjectGetResponseModel> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new ProjectGetResponseModel();
        }
    }
}
