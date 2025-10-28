using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webhooks.Practice.Application.Contracts;
using Webhooks.Practice.Application.UnitOfWorks;
using Webhooks.Practice.Infrastructure.Persistence.DbContexts;
using Webhooks.Practice.Infrastructure.Persistence.Repositories;
using Webhooks.Practice.Infrastructure.Persistence.UnitOfWorks;

namespace Webhooks.Practice.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Registrar implementaciones concretas (opcional pero recomendado)
            services.AddScoped<ProductRepository>();
            services.AddScoped<UnitOfWork>();

            // Registrar interfaces (mejor con AddScoped<TInterface, TImplementation>)
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
