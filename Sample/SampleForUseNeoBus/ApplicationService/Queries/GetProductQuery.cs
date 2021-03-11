using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.ApplicationService.Queries
{
    public class GetProductQuery : Query<CommandResult>
    {
        public int ProductId { get; set; }
    }
}
