using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
