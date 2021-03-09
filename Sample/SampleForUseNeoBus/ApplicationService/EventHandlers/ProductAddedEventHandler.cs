using NeoBus.MessageBus.Abstractions;
using SampleForUseNeoBus.Domain.Catalog;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.EventHandlers
{
    public class ProductAddedEventHandler : ICanHandleEvent<ProductAddedEvent>
    {
        public ProductAddedEventHandler()
        {
            
        }

        public async Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            // Do Something ...
        }
    }
}
