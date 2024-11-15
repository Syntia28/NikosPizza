using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities.Identity;
namespace NikosPizza.Infraestructure.Configuration
{
    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.HasMany<ApplicationUserRole>(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
