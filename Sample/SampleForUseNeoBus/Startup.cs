using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddMediatR(typeof(Startup));
            services.AddScoped<CatalogUseCase>();

            services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();
            services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
