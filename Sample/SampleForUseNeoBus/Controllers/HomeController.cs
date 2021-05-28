using Microsoft.AspNetCore.Mvc;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService;
using SampleForUseNeoBus.ApplicationService.Catalog.AddProduct;
using SampleForUseNeoBus.ApplicationService.Catalog.GetProductDetail;
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
            var command = new AddProductCommand
            {
                Name = request.Name,
                Price = request.Price
            };

            var result = catalog.AddProductAsync(command);
            return result;
        }

        [HttpGet]
        public Task<CommandResult> GetAsync(int id)
        {
            var query = new GetProductDetailQuery
            {
                ProductId = id
            };

            var result = catalog.GetProductByIdAsync(query);
            return result;
        }
    }
}
