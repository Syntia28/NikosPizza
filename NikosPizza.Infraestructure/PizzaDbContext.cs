using Microsoft.EntityFrameworkCore;
using NikosPizza.core.Entities;
using NikosPizza.Infraestructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Infraestructure
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }



        public void ModelConfiguration(ModelBuilder modelBuilder)
        {
            new PizzaConfiguration(modelBuilder.Entity<Pizza>());
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("pizza");
        }
    }
}
