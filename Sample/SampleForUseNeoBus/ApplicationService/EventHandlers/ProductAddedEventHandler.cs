using NeoBus.Kafka.EntityReplication;
using NeoBus.MessageBus.Abstractions;
using SampleForUseNeoBus.Domain.Catalog;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.EventHandlers
{
    public class ProductAddedEventHandler : ICanHandleEvent<ProductAddedEvent>
    {
        public ProductAddedEventHandler(KafkaEntityPublisher<Product, int> publisher)
        {
            Publisher = publisher;
        }

        public KafkaEntityPublisher<Product, int> Publisher { get; }

        public async Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            // Do Something ...
        }
    }
}
