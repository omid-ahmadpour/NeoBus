using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NeoBus.Kafka.Models;
using System;
using System.Threading.Tasks;

namespace NeoBus.Kafka.EntityReplication
{
    public class KafkaEntityPublisher<TEntity, T>
    {
        public DbContext Context { get; }
        private KafkaProducer<EntityChangeEvent<TEntity, T>> ChangeProducer { get; }


        public KafkaEntityPublisher(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            ChangeProducer = new KafkaProducer<EntityChangeEvent<TEntity, T>>($"EntityChangesTopic", configuration.GetSection("HolooCloud:Kafka:Servers").Get<string[]>(), serviceProvider);
        }

        public virtual async Task PublishChange(TEntity entity, T UserId, EntityChangeType changeType)
        {
            await ChangeProducer.Produce(new EntityChangeEvent<TEntity, T>()
            {
                Data = entity,
                UserId = UserId,
                ChangeType = changeType,
                EntityType = typeof(TEntity).Name,
            });
        }


    }
}
