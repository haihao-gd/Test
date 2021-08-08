using MediatR;

namespace ZeroStack.DeviceCenter.Application.Infrastructure
{
    public class IdentifiedCommand<TRequest, TResponse> : IRequest<TResponse> where TRequest : IRequest<TResponse>
    {
        public TRequest Command { get; }

        public string Id { get; set; }

        public IdentifiedCommand(TRequest command, string id)
        {
            Command = command;
            Id = id;
        }
    }
}
