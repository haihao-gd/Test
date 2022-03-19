using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ZeroStack.IdentityServer.API.Models;

namespace ZeroStack.IdentityServer.API.Infrastructure.Tenants
{
    public class IdentityProfileService : ProfileService<ApplicationUser>
    {
        public IdentityProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory) : base(userManager, claimsFactory)
        {
        }

        public IdentityProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, ILogger<ProfileService<ApplicationUser>> logger) : base(userManager, claimsFactory, logger)
        {
        }

        protected override Task GetProfileDataAsync(ProfileDataRequestContext context, ApplicationUser user)
        {
            return base.GetProfileDataAsync(context, user);
        }
    }
}
