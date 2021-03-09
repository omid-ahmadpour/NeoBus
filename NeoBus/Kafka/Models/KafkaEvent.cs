namespace NeoBus.Kafka.Models
{
    public class KafkaEvent<T1, T2>
    {
        public T1 Data { get; set; }
        public T2 UserId { get; set; }
    }
}