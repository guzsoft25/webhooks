using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Webhooks.Practice.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(service => service.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
