using NeoBus.MessageBus.Abstractions;
using SampleForUseNeoBus.Domain.Catalog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.EventHandlers
{
    public class ProductAddedEventOnKafkaHandler : ICanHandleEvent<ProductAddedEventOnKafka>
    {
        public Task Handle(ProductAddedEventOnKafka notification, CancellationToken cancellationToken)
        {
            //Do Your Function

            Console.WriteLine("Event Received From Event Handler.");
            return Task.CompletedTask;
        }
    }
}
