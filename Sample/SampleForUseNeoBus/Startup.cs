using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeoBus;
using NeoBus.Kafka;
using SampleForUseNeoBus.ApplicationService.EventHandlers;
using SampleForUseNeoBus.Domain.Catalog;
using System.Reflection;

namespace SampleForUseNeoBus
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NeoBus Sample Use", Version = "v1" });
            });

            services.AddNeoBus(Assembly.GetExecutingAssembly());

            //Register Distributed Events(Event On Kafka)
            services.AddHostedService<KafkaEventSubscriberService<ProductAddedEventOnKafka, ProductAddedEventOnKafkaHandler>>();

            services.AddSingleton<ProductAddedEventOnKafkaHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample For Use NeoBus"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
