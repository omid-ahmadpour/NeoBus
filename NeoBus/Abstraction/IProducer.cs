using System.Threading.Tasks;

namespace NeoBus.Abstraction
{
    public interface IProducer<TEvent>
    {
        Task Produce(TEvent data);
        Task ProduceEvent(TEvent data);
    }
}
