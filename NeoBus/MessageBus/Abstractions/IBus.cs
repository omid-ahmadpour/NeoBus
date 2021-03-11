using NeoBus.MessageBus.Models;
using System.Threading.Tasks;

namespace NeoBus.MessageBus.Abstractions
{
    public interface IBus
    {
        Task<CommandResult> SendCommandAsync<T>(T command) where T : Command<CommandResult>;

        Task<CommandResult> SendQueryAsync<T>(T query) where T : Query<CommandResult>;

        Task RaiseEvent<T>(T @event, RaiseEventOn raiseEventOn = RaiseEventOn.Local) where T : Event;
    }
}