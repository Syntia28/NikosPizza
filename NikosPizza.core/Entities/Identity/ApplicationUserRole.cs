﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.core.Entities.Identity
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUserRole() { }
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}