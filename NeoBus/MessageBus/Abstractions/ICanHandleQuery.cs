using MediatR;

namespace NeoBus.MessageBus.Abstractions
{
    public interface ICanHandleQuery<TCommand> : IRequestHandler<TCommand,TCommand> where TCommand : IRequest<TCommand>
    {

    }
}
