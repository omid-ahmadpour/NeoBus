using MediatR;

namespace NeoBus.MessageBus.Abstractions
{
    public interface ICanHandleEvent<TEvent> : INotificationHandler<TEvent> where TEvent : INotification
    {
        
    }
}
