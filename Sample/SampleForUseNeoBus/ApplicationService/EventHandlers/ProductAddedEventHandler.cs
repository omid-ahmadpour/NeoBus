using Microsoft.Extensions.Logging;
using NeoBus.MessageBus.Abstractions;
using SampleForUseNeoBus.Domain.Catalog;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.EventHandlers
{
    public class ProductAddedEventHandler : ICanHandleEvent<ProductAddedEvent>
    {
        private readonly ILogger<ProductAddedEventHandler> logger;

        public ProductAddedEventHandler(ILogger<ProductAddedEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Event Received From ProductAddedEvent: " + notification);
            // Do Something ...
            return Task.CompletedTask;
        }
    }
}
