using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.ApplicationService.Catalog.AddProduct
{
    public class AddProductCommand : Command<CommandResult>
    {
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
