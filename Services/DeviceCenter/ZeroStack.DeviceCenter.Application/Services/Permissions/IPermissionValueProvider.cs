using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Application.Services.Permissions
{
    public interface IPermissionValueProvider
    {
        string Name { get; }

        Task<PermissionGrantResult> CheckAsync(ClaimsPrincipal principal, PermissionDefinition permission);

        Task<MultiplePermissionGrantResult> CheckAsync(ClaimsPrincipal principal, List<PermissionDefinition> permissions);
    }
}
