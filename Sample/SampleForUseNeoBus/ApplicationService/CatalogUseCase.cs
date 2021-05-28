using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Catalog.AddProduct;
using SampleForUseNeoBus.ApplicationService.Catalog.GetProductDetail;
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

        public async Task<CommandResult> AddProductAsync(AddProductCommand command)
        {
            var result = await Bus.SendCommandAsync(command);
            return result;
        }

        public async Task<CommandResult> GetProductByIdAsync(GetProductDetailQuery query)
        {
            var result = await Bus.SendQueryAsync(query);
            return result;
        }
    }
}
