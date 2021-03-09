namespace NeoBus.MessageBus.Models
{
    public enum RaiseEventOn
    {
        Local = 1 << 1,

        Kafka = 1 << 2,

        All = Local | Kafka
    }
}
