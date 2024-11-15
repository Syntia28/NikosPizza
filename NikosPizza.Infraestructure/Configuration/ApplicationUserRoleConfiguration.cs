using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Infraestructure.Configuration
{
    public class ApplicationUserRoleConfiguration
    {
        public ApplicationUserRoleConfiguration(EntityTypeBuilder<IdentityUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
        }
    }
}
