using System.Collections.Generic;

namespace NeoBus.Abstraction
{
    public interface IConsumer<T>
    {
        IEnumerable<T> Consume(bool autoCommit = true);

        void Commit();

        T ConsumeOne(bool autoCommit);
    }
}
