using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeoBus.Kafka;
using NeoBus.Kafka.EntityReplication;
using NeoBus.MessageBus;
using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService;
using SampleForUseNeoBus.ApplicationService.CommandHandlers;
using SampleForUseNeoBus.ApplicationService.Commands;
using SampleForUseNeoBus.ApplicationService.EventHandlers;
using SampleForUseNeoBus.Domain.Catalog;

namespace SampleForUseNeoBus
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            services.AddScoped<CatalogUseCase>();

            services.AddSingleton(typeof(KafkaProducer<>));

            services.AddSingleton(typeof(KafkaEntityPublisher<,>));

            services.AddScoped<IBus, Bus>();

            services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();
            services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
