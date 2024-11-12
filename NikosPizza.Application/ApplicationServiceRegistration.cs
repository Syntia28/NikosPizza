


using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NikosPizza.core.Entities;

namespace NikosPizza.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
        

    }
}