using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NeoBus.Kafka;
using NeoBus.MessageBus;
using NeoBus.MessageBus.Abstractions;
using System.Reflection;
using System.Threading;

namespace NeoBus
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNeoBus(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton(x => new SemaphoreSlim(1));

            services.AddSingleton(typeof(KafkaProducer<>));

            services.AddScoped<IBus, Bus>();

            return services;
        }
    }
}
