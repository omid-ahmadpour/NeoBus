using MediatR;

namespace NeoBus.MessageBus.Models
{
    public class Query<TResponse> : IRequest<TResponse>
    {
    }
}
