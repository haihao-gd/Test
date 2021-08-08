using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Infrastructure.Idempotency;

namespace ZeroStack.DeviceCenter.Application.Infrastructure
{
    public class IdentifiedCommandHandler<TRequest, TResponse> : IRequestHandler<IdentifiedCommand<TRequest, TResponse>, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IMediator _mediator;

        private readonly IRequestManager _requestManager;

        public IdentifiedCommandHandler(IMediator mediator, IRequestManager requestManager)
        {
            _mediator = mediator;
            _requestManager = requestManager;
        }

        protected virtual TResponse? CreateResultForDuplicateRequest() => default;

        public async Task<TResponse> Handle(IdentifiedCommand<TRequest, TResponse> request, CancellationToken cancellationToken)
        {
            if (await _requestManager.ExistAsync(request.Id))
            {
                return CreateResultForDuplicateRequest() ?? throw new NotImplementedException();
            }

            await _requestManager.CreateRequestForCommandAsync<TRequest>(request.Id);

            return await _mediator.Send(request.Command, cancellationToken);
        }
    }
}
