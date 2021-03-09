using Microsoft.AspNetCore.Mvc;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService;
using SampleForUseNeoBus.ApplicationService.Commands;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly CatalogUseCase catalog;

        public HomeController(CatalogUseCase catalog)
        {
            this.catalog = catalog;
        }

        [HttpPost("add")]
        public Task<CommandResult> AddAsync(ProductAddRequest request)
        {
            var command = new ProductAddCommand
            {
                Name = request.Name,
                Price = request.Price
            };

            var result = catalog.AddProduct(command);
            return result;
        }
    }
}
