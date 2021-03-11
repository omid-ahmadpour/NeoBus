using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Commands;
using SampleForUseNeoBus.ApplicationService.Queries;
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

        public async Task<CommandResult> AddProductAsync(ProductAddCommand command)
        {
            var result = await Bus.SendCommandAsync(command);
            return result;
        }

        public async Task<CommandResult> GetProductByIdAsync(GetProductQuery query)
        {
            var result = await Bus.SendQueryAsync(query);
            return result;
        }
    }
}
