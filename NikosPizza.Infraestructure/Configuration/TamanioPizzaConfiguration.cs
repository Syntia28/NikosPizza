using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities;

namespace NikosPizza.Infraestructure.Configuration
{
    public class TamanioPizzaConfiguration
    {
         public TamanioPizzaConfiguration(EntityTypeBuilder<TamanioPizza> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(x=>x.TamanioPizzaId);
        }
    }
}