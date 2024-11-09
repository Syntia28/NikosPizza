
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities;

namespace NikosPizza.Infraestructure.Configuration
{
    public class PizzaConfiguration
    {
        public PizzaConfiguration(EntityTypeBuilder<Pizza> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(x=>x.PizzaId);
        }
    }
}
