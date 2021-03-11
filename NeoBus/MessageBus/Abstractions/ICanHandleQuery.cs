using MediatR;
using NeoBus.MessageBus.Models;

namespace NeoBus.MessageBus.Abstractions
{
    public interface ICanHandleQuery<TRequest> : IRequestHandler<TRequest, CommandResult> where TRequest : IRequest<CommandResult>
    {

    }
}
