using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.Domain.Catalog
{
    public class ProductAddedEvent : Event
    {
        public ProductAddedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}
