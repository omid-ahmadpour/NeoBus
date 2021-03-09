using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Commands;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService
{
    public class CatalogUseCase
    {
        public CatalogUseCase(IBus bus)
        {
            Bus = bus;
        }

        public IBus Bus { get; }

        public async Task<CommandResult> AddProduct(ProductAddCommand command)
        {
            var result = await Bus.SendCommandAsync(command);
            return result;
        }
    }
}
