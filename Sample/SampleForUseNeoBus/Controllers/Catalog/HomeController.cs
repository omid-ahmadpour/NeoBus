using Microsoft.AspNetCore.Mvc;
using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Catalog.AddProduct;
using SampleForUseNeoBus.ApplicationService.Catalog.GetProductDetail;
using SampleForUseNeoBus.Controllers.Catalog.Requests;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBus _bus;

        public HomeController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("add")]
        public Task<CommandResult> AddAsync(AddProductRequest request)
        {
            var command = new AddProductCommand
            {
                Name = request.Name,
                Price = request.Price
            };

            var result = _bus.SendCommandAsync(command);
            return result;
        }

        [HttpGet]
        public Task<CommandResult> GetAsync(int id)
        {
            var query = new GetProductDetailQuery
            {
                ProductId = id
            };

            var result = _bus.SendQueryAsync(query);
            return result;
        }
    }
}
