using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace NeoBus.Kafka.Serializers
{
    public class UTF8JsonSerializer<T> : ISerializer<T>
    {
        public ILogger<UTF8JsonSerializer<T>> Logger { get; }

        public UTF8JsonSerializer(ILogger<UTF8JsonSerializer<T>> logger)
        {
            Logger = logger;
        }
        public byte[] Serialize(T data, SerializationContext context)
        {

            var serializeData = Utf8Json.JsonSerializer.NonGeneric.Serialize(data);
            Logger.LogInformation(20001, Encoding.UTF8.GetString(serializeData));
            return serializeData;
        }
    }

    public class UTF8JsonDeserializer<T> : IDeserializer<T>
    {
        public ILogger<UTF8JsonDeserializer<T>> Logger { get; }

        public UTF8JsonDeserializer(ILogger<UTF8JsonDeserializer<T>> logger)
        {
            Logger = logger;
        }

        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            var deserializedData = Utf8Json.JsonSerializer.Deserialize<T>(data.ToArray());
            Logger.LogInformation(20002, Encoding.UTF8.GetString(data));
            return deserializedData;
        }
    }
}
