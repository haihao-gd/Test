using Microsoft.AspNetCore.Identity;
using System;

namespace ZeroStack.IdentityServer.API.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Guid? TenantId { get; set; }
    }
}
