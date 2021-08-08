using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Infrastructure;
using ZeroStack.DeviceCenter.Application.Models.Projects;
using ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate;
using ZeroStack.DeviceCenter.Domain.Repositories;
using ZeroStack.DeviceCenter.Infrastructure.Idempotency;

namespace ZeroStack.DeviceCenter.Application.Commands.Projects
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectGetResponseModel>
    {
        private readonly IRepository<Project> _projectRepository;

        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectGetResponseModel> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _mapper.Map<Project>(request);
            project = await _projectRepository.InsertAsync(project, true, cancellationToken);
            return _mapper.Map<ProjectGetResponseModel>(project);
        }
    }

    public class CreateProjectIdentifiedCommandHandler : IdentifiedCommandHandler<CreateProjectCommand, ProjectGetResponseModel>
    {
        public CreateProjectIdentifiedCommandHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
        {
        }

        /// <summary>
        /// // Ignore duplicate requests for processing.
        /// </summary>
        protected override ProjectGetResponseModel? CreateResultForDuplicateRequest() => new ProjectGetResponseModel();
    }
}
