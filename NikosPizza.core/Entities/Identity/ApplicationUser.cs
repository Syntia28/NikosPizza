using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
