using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NikosPizza.core.Entities;
using NikosPizza.core.Entities.Identity;
using NikosPizza.Infraestructure.Configuration;

namespace NikosPizza.Infraestructure
{
    public class PizzaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, // TUserClaim
        ApplicationUserRole, // TUserRole,
        IdentityUserLogin<string>, // TUserLogin
        IdentityRoleClaim<string>, // TRoleClaim
        IdentityUserToken<string>>

    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<TamanioPizza> TamanioPizzas { get; set; }



        public void ModelConfiguration(ModelBuilder modelBuilder)
        {
            new PizzaConfiguration(modelBuilder.Entity<Pizza>());
            new TamanioPizzaConfiguration(modelBuilder.Entity<TamanioPizza>());
            new ApplicationUserConfiguration(modelBuilder.Entity<ApplicationUser>());
            new ApplicationRoleConfiguration(modelBuilder.Entity<ApplicationRole>());
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfiguration(modelBuilder);
            modelBuilder.HasDefaultSchema("pizza");
        }
    }
}
