using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NikosPizza.Application.Repositories;
using NikosPizza.Infraestructure.Repositories;

namespace NikosPizza.Infraestructure
{
    public static class InfrectuctureServicePizza
    {
        public static IServiceCollection AddInfrectuctureServicePizza(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PizzaDbContext>(ops =>
                    ops.UseSqlServer(
                        configuration.GetConnectionString("ConnectionSQLServer"),
                        x => x.MigrationsHistoryTable("_EFMigrationHistory", "pizza")
                        )
            );
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<ITamanioPizzaRepository, TamanioPizzaRepository>();

            return services;
        }
    }
}
