using Microsoft.OpenApi.Models;
using Webhooks.Practice.Application;
using Webhooks.Practice.Infrastructure;

namespace Webhooks.Practice.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductWebhookDemo API", Version = "v1" }));

            // Clean architecture registrations
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            app.Run();
        }
    }
}
