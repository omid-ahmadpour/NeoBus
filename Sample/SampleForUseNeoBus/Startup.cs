using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeoBus;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService;
using SampleForUseNeoBus.ApplicationService.CommandHandlers;
using SampleForUseNeoBus.ApplicationService.Commands;
using SampleForUseNeoBus.ApplicationService.EventHandlers;
using SampleForUseNeoBus.ApplicationService.Queries;
using SampleForUseNeoBus.ApplicationService.QueryHandlers;
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NeoBus Sample Use", Version = "v1" });
            });

            services.AddScoped<CatalogUseCase>();

            services.AddNeoBus();

            services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();
            services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
            services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
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

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
