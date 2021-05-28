using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.ApplicationService.Catalog.GetProductDetail
{
    public class GetProductDetailQuery : Query<CommandResult>
    {
        public int ProductId { get; set; }
    }
}
