using MediatR;
using NeoBus.Kafka;
using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using System;
using System.Threading.Tasks;

namespace NeoBus.MessageBus
{
    public class Bus : IBus
    {
        private readonly IMediator mediator;

        public IServiceProvider ServiceProvider { get; }

        public Bus(IMediator mediator,
                   IServiceProvider serviceProvider)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            ServiceProvider = serviceProvider;
        }

        public async Task<CommandResult> SendCommandAsync<T>(T command) where T : Command<CommandResult>
        {
            return await mediator.Send(command);
        }

        public async Task<CommandResult> SendQueryAsync<T>(T query) where T : Query<CommandResult>
        {
            return await mediator.Send(query);
        }

        public async Task RaiseEvent<T>(T @event, RaiseEventOn raiseEventOn = RaiseEventOn.Local) where T : Event
        {
            if ((raiseEventOn & RaiseEventOn.Local) != 0)
            {
                await mediator.Publish(@event);
            }

            if ((raiseEventOn & RaiseEventOn.Kafka) != 0)
            {
                var eventProducer = (KafkaProducer<T>)ServiceProvider.GetService(typeof(KafkaProducer<T>));
                await eventProducer.ProduceEvent(@event);
            }
        }



    }
}
