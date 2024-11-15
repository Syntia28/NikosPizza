using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikosPizza.core.Entities.Identity;


namespace NikosPizza.Infraestructure.Configuration
{
    public class ApplicationUserRoleConfiguration
    {
        public ApplicationUserRoleConfiguration(EntityTypeBuilder<ApplicationUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
        }
    }
}
