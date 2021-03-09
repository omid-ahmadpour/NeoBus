using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.ApplicationService.Queries
{
    public class GetProductQuery : Query<string>
    {
        public int Id { get; set; }
    }
}
