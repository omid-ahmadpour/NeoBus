using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.ApplicationService.Commands
{
    public class ProductAddCommand : Command<CommandResult>
    {
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
