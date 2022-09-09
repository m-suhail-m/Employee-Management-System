using Employee_Management_System_API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Factory
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public UserClaimsPrincipalFactory(UserManager<User> userManager,
           RoleManager<IdentityRole> roleManager,
           IOptions<IdentityOptions> optionsAccessor)
           : base(userManager, roleManager, optionsAccessor)
        {

        }
    }
}
