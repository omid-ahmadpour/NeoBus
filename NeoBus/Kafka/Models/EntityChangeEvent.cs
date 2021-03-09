using ZeroFormatter;

namespace NeoBus.Kafka.Models
{
    [ZeroFormattable]
    public class EntityChangeEvent<TEntity, T> : KafkaEvent<TEntity, T>
    {
        public EntityChangeType ChangeType { get; set; }
        public string EntityType { get; set; }

    }
}
