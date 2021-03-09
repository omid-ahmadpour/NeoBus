using MediatR;
using NeoBus.MessageBus.Models;

namespace NeoBus.MessageBus.Abstractions
{
    public interface ICanHandleCommand<TCommand> : IRequestHandler<TCommand,CommandResult> where TCommand : IRequest<CommandResult>
    {

    }
}
