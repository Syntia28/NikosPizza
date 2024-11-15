using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Infraestructure.Configuration
{
   public class ApplicationRoleConfiguration
    {
        public ApplicationRoleConfiguration(EntityTypeBuilder<IdentityUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany<ApplicationUserRole>(x => x.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x=>x.RoleId);

            entityTypeBuilder.Property(x => x.Descripcion)
                             .IsRequired(false);
        }
    }
}
