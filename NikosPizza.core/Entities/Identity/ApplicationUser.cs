using Microsoft.AspNetCore.Identity;

namespace NikosPizza.core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
