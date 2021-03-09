using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Commands;
using SampleForUseNeoBus.Domain.Catalog;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.CommandHandlers
{
    public class ProductAddCommandHandler : ICanHandleCommand<ProductAddCommand>
    {
        public ProductAddCommandHandler(IBus bus)
        {
            Bus = bus;
        }

        public IBus Bus { get; }

        public async Task<CommandResult> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await Bus.RaiseEvent(new ProductAddedEvent(product));

            return commandResult;
        }
    }
}
