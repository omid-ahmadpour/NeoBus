using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NeoBus.Kafka.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NeoBus.Kafka.EntityReplication
{
    public class KafkaEntitySubscriberService<TEntity, TContext> : IHostedService where TEntity : class
                                                                           where TContext : DbContext
    {

        public ILogger<KafkaEntitySubscriberService<TEntity, TContext>> Logger { get; }
        public IServiceProvider ServiceProvider { get; }
        private KafkaConsumer<EntityChangeEvent<TEntity, int>> EventConsumer { get; }

        public KafkaEntitySubscriberService(TContext context, IConfiguration configuration, ILogger<KafkaEntitySubscriberService<TEntity, TContext>> logger, IServiceProvider serviceProvider)
        {
            Logger = logger;
            ServiceProvider = serviceProvider;
            EventConsumer = new KafkaConsumer<EntityChangeEvent<TEntity, int>>($"EntityChangesTopic", configuration.GetSection("NeoBus:Kafka:Servers").Get<string[]>(), serviceProvider);
        }

        public virtual async Task HandleChanges()
        {
            foreach (var changeEvent in EventConsumer.Consume())
            {
                try
                {

                    switch (changeEvent.ChangeType)
                    {
                        case EntityChangeType.Add:
                            await HandleAdds(changeEvent.Data);
                            break;
                        case EntityChangeType.Delete:
                            await HandleDeletes(changeEvent.Data);
                            break;
                        case EntityChangeType.Update:
                            await HandleUpdates(changeEvent.Data);
                            break;

                    }

                    EventConsumer.Commit();

                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                }
            }
        }


        public virtual async Task HandleUpdates(TEntity entity)
        {
            try
            {
                using (var scope = ServiceProvider.CreateScope())
                {
                    var transientDbContext = scope.ServiceProvider.GetService<TContext>();
                    transientDbContext.Set<TEntity>().Local.Clear();
                    transientDbContext.Set<TEntity>().Update(entity);
                    await transientDbContext.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }

        public virtual async Task HandleDeletes(TEntity entity)
        {
            try
            {
                using (var scope = ServiceProvider.CreateScope())
                {
                    var transientDbContext = scope.ServiceProvider.GetService<TContext>();
                    transientDbContext.Set<TEntity>().Remove(entity);
                    await transientDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }

        public virtual async Task HandleAdds(TEntity entity)
        {
            try
            {
                using (var scope = ServiceProvider.CreateScope())
                {
                    var transientDbContext = scope.ServiceProvider.GetService<TContext>();
                    await transientDbContext.Set<TEntity>().AddAsync(entity);
                    await transientDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var handleUpdatesTask = Task.Run(async () =>
            {
                await HandleChanges();
            }, cancellationToken);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
