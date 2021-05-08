using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZeroStack.IdentityServer.API.Models;

namespace ZeroStack.IdentityServer.API.Infrastructure.Tenants
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public CustomUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity claimsIdentity = await base.GenerateClaimsAsync(user);

            if (user.TenantId.HasValue)
            {
                claimsIdentity.AddClaim(new Claim(TenantClaimTypes.TenantId, user.TenantId.Value.ToString()));
            }

            return claimsIdentity;
        }
    }
}
