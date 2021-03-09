using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NeoBus.Abstraction;
using NeoBus.Kafka.Serializers;
using NeoBus.MessageBus.Models;
using System;
using System.Threading.Tasks;

namespace NeoBus.Kafka
{
    public class KafkaProducer<T> : IProducer<T>
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public string Topic { get; }

        private static ProducerConfig KafkaProducerConfig;

        public ILogger<KafkaProducer<T>> Logger { get; }


        private static IProducer<Null, T> producer = null;

        private static IProducer<Null, T> Producer
        {
            get
            {
                if (producer != null)
                    return producer;

                KafkaProducerConfig.MessageTimeoutMs = 10000;

                var builder = new ProducerBuilder<Null, T>(KafkaProducerConfig);
                builder.SetValueSerializer(new UTF8JsonSerializer<T>((ILogger<UTF8JsonSerializer<T>>)ServiceProvider.GetService(typeof(ILogger<UTF8JsonSerializer<T>>))));

                producer = builder.Build();
                return producer;
            }
        }

        public KafkaProducer(string topic, string[] servers, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Topic = $"{topic}_{Environment.GetEnvironmentVariable("KAFKA_ENVIRONMENT")}";
            KafkaProducerConfig = new ProducerConfig
            {
                BootstrapServers = string.Join(",", servers)
            };

            Logger = (ILogger<KafkaProducer<T>>)serviceProvider.GetService(typeof(ILogger<KafkaProducer<T>>));
        }

        public KafkaProducer(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Topic = $"{typeof(T).Name}_{Environment.GetEnvironmentVariable("KAFKA_ENVIRONMENT")}";
            KafkaProducerConfig = new ProducerConfig
            {
                BootstrapServers = string.Join(",", configuration.GetSection("NeoBus:Kafka:Servers").Get<string[]>())
            };

            Logger = (ILogger<KafkaProducer<T>>)serviceProvider.GetService(typeof(ILogger<KafkaProducer<T>>));
        }

        public async Task Produce(T data)
        {
            var result = await Producer.ProduceAsync(Topic, new Message<Null, T> { Value = data });
            Logger.LogInformation(20001, typeof(T).Name);
            Logger.LogInformation(20001, Topic);
        }

        public async Task ProduceEvent(T @event)
        {
            if (!(@event is Event)) throw new InvalidOperationException();

            var result = await Producer.ProduceAsync($"{typeof(T).Name}_{Environment.GetEnvironmentVariable("KAFKA_ENVIRONMENT")}", new Message<Null, T> { Value = @event });
            Logger.LogInformation(20001, typeof(T).Name);
        }
    }
}
