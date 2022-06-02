using Microsoft.Extensions.Logging;
using NeoBus.MessageBus.Abstractions;
using SampleForUseNeoBus.Domain.Catalog;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.EventHandlers
{
    public class ProductAddedEventOnKafkaHandler : ICanHandleEvent<ProductAddedEventOnKafka>
    {
        private readonly ILogger<ProductAddedEventOnKafkaHandler> _logger;

        public ProductAddedEventOnKafkaHandler(ILogger<ProductAddedEventOnKafkaHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductAddedEventOnKafka notification, CancellationToken cancellationToken)
        {
            //Do Your Function

            _logger.LogInformation("Event Received From Event Handler: " + notification);
            return Task.CompletedTask;
        }
    }
}
