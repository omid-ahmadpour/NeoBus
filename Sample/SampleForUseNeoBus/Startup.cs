using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeoBus;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService;
using SampleForUseNeoBus.ApplicationService.Catalog.AddProduct;
using SampleForUseNeoBus.ApplicationService.Catalog.GetProductDetail;
using SampleForUseNeoBus.ApplicationService.CommandHandlers;
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NeoBus Sample Use", Version = "v1" });
            });

            services.AddNeoBus();

            //Register Commands
            services.AddScoped<IRequestHandler<AddProductCommand, CommandResult>, AddProductCommandHandler>();

            //Register Queries
            services.AddScoped<IRequestHandler<GetProductDetailQuery, CommandResult>, GetProductDetailQueryHandler>();

            //Register Events
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
