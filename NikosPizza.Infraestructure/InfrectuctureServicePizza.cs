



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

            return services;
        }
    }
}
