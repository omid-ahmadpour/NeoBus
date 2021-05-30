using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Catalog.AddProduct;
using SampleForUseNeoBus.Domain.Catalog;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.CommandHandlers
{
    public class AddProductCommandHandler : ICanHandleCommand<AddProductCommand>
    {
        public AddProductCommandHandler(IBus bus)
        {
            Bus = bus ?? throw new System.ArgumentNullException(nameof(bus));
        }

        public IBus Bus { get; }

        public async Task<CommandResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await Bus.RaiseEvent(new ProductAddedEvent(product));

            await Bus.RaiseEvent(new ProductAddedEventOnKafka(product),raiseEventOn: RaiseEventOn.Kafka);

            return commandResult;
        }
    }
}
