using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities.Identity;


namespace NikosPizza.Infraestructure.Configuration
{
    public class ApplicationRoleConfiguration
    {
        public ApplicationRoleConfiguration(EntityTypeBuilder<ApplicationRole> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.HasMany<ApplicationUserRole>(x => x.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);

            entityTypeBuilder.Property(x => x.Descripcion)
                             .IsRequired(false);
        }
    }
}
