using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NeoBus.Kafka
{
    public class KafkaEventSubscriberService<TEvent, TEventHandler> : IHostedService where TEvent : Event
                                                                                     where TEventHandler : ICanHandleEvent<TEvent>
    {
        public IBus Bus { get; }

        public IServiceProvider ServiceProvider { get; }

        public TEventHandler EventHandler { get; }

        public ILogger<KafkaEventSubscriberService<TEvent, TEventHandler>> Logger { get; }

        private KafkaConsumer<TEvent> EventConsumer { get; }

        public KafkaEventSubscriberService(IBus bus, IServiceProvider serviceProvider, IConfiguration configuration, TEventHandler eventHandler, ILogger<KafkaEventSubscriberService<TEvent, TEventHandler>> logger)
        {
            Bus = bus;
            ServiceProvider = serviceProvider;
            EventHandler = eventHandler;
            Logger = logger;
            EventConsumer = new KafkaConsumer<TEvent>(typeof(TEvent).Name, configuration.GetSection("NeoBus:Kafka:Servers").Get<string[]>(), serviceProvider);
        }

        public virtual async Task HandleEvents()
        {
            foreach (var kafkaEvent in EventConsumer.Consume(autoCommit: false))
            {
                Logger.LogInformation(5656, $"{kafkaEvent}");
                var scopedSemaphoreSlim = (SemaphoreSlim)ServiceProvider.GetService(typeof(SemaphoreSlim));

                try
                {
                    await scopedSemaphoreSlim.WaitAsync();
                    await EventHandler.Handle(kafkaEvent, CancellationToken.None);

                    EventConsumer.Commit();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, ex.Message);
                }
                finally
                {
                    scopedSemaphoreSlim.Release();
                }
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var handleUpdatesTask = Task.Run(async () =>
            {
                await HandleEvents();
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
