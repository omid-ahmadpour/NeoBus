using MediatR;

namespace NeoBus.MessageBus.Models
{
    public class Command<TResponse> : IRequest<TResponse>
    {
    }
}
