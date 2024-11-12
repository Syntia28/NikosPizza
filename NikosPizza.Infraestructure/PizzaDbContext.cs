using Microsoft.EntityFrameworkCore;
using NikosPizza.core.Entities;
using NikosPizza.Infraestructure.Configuration;

namespace NikosPizza.Infraestructure
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<TamanioPizza> TamanioPizzas { get; set; }
       



        public void ModelConfiguration(ModelBuilder modelBuilder)
        {
            new PizzaConfiguration(modelBuilder.Entity<Pizza>());
            new TamanioPizzaConfiguration(modelBuilder.Entity<TamanioPizza>());
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("pizza");
        }
    }
}
