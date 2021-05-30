using NeoBus.MessageBus.Models;

namespace SampleForUseNeoBus.Domain.Catalog
{
    public class ProductAddedEventOnKafka : Event
    {
        public ProductAddedEventOnKafka(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}
