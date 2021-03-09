using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using NeoBus.Abstraction;
using NeoBus.Kafka.Serializers;
using System;
using System.Collections.Generic;

namespace NeoBus.Kafka
{
    public class KafkaConsumer<T> : IConsumer<T>
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public string Topic { get; }

        private static ConsumerConfig ConsumerConfig = null;

        public ILogger<KafkaConsumer<T>> Logger { get; }

        private static IConsumer<Null, T> consumer = null;

        private static IConsumer<Null, T> Consumer
        {
            get
            {
                if (consumer != null)
                    return consumer;

                var builder = new ConsumerBuilder<Null, T>(ConsumerConfig);
                builder.SetValueDeserializer(new UTF8JsonDeserializer<T>((ILogger<UTF8JsonDeserializer<T>>)ServiceProvider.GetService(typeof(ILogger<UTF8JsonDeserializer<T>>))));

                consumer = builder.Build();
                return consumer;
            }
        }

        public KafkaConsumer(string topic, string[] servers, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Topic = $"{topic}_{Environment.GetEnvironmentVariable("KAFKA_ENVIRONMENT")}";
            Logger = (ILogger<KafkaConsumer<T>>)serviceProvider.GetService(typeof(ILogger<KafkaConsumer<T>>));
            Logger.LogInformation(20001, "TopicName = " + Topic);
            Logger.LogInformation(20001, "GroupId = " + $"{typeof(T).Name}-{Environment.GetEnvironmentVariable("KAFKA_ENVIRONMENT")}-consumer");
            Logger.LogInformation(20001, "BootstrapServers = " + string.Join(",", servers));

            ConsumerConfig = new ConsumerConfig
            {
                BootstrapServers = string.Join(",", servers),
                GroupId = $"{typeof(T).Name}-{Environment.GetEnvironmentVariable("KAFKA_ENVIRONMENT")}-consumer",
                EnableAutoCommit = false,
                StatisticsIntervalMs = 5000,
                SessionTimeoutMs = 6000,
            };

            if (!Consumer.Subscription.Contains(topic))
                Consumer.Subscribe(Topic);
        }

        public IEnumerable<T> Consume(bool autoCommit = true)
        {
            while (true)
            {
                T data = ConsumeOne(autoCommit);

                if (data != null)
                    yield return data;
            }
        }
        
        public void Commit()
        {
            Consumer.Commit();
        }

        public T ConsumeOne(bool autoCommit)
        {
            T data = default;
            try
            {
                var result = Consumer.Consume();
                data = result.Value;
                if (autoCommit)
                {
                    Consumer.Commit();
                }

                Logger.LogInformation(20002, $"Consumed message at: '{result.TopicPartitionOffset}'.");
            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"Error occured: {e.Error.Reason}");
            }

            return data;
        }
    }
}
