using NeoBus.MessageBus.Models;
using System.Threading.Tasks;

namespace NeoBus.MessageBus.Abstractions
{
    public interface IBus
    {
        Task<CommandResult> SendCommandAsync<T>(T command) where T : Command<CommandResult>;

        Task RaiseEvent<T>(T @event, RaiseEventOn raiseEventOn = RaiseEventOn.Local) where T : Event;
    }
}