using MediatR;
using System;

namespace NeoBus.MessageBus.Models
{
    public class Event : INotification
    {
        public DateTime EventDate { get; set; } = DateTime.UtcNow;
    }
}
