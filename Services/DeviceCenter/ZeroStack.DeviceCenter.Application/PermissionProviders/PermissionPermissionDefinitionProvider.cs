using Microsoft.Extensions.Localization;
using System.Reflection;
using ZeroStack.DeviceCenter.Application.Services.Permissions;

namespace ZeroStack.DeviceCenter.Application.PermissionProviders
{
    public class PermissionPermissionDefinitionProvider : IPermissionDefinitionProvider
    {
        private readonly IStringLocalizer _localizer;

        public PermissionPermissionDefinitionProvider(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Welcome", Assembly.GetExecutingAssembly().FullName ?? string.Empty);
        }

        public void Define(PermissionDefinitionContext context)
        {
            var productGroup = context.AddGroup(PermissionPermissions.GroupName, _localizer["Permission:PermissionManager"]);

            var productManagement = productGroup.AddPermission(PermissionPermissions.Permissions.Default, _localizer["Permission:PermissionStore.Permissions"]);

            productManagement.AddChild(PermissionPermissions.Permissions.Get, _localizer["Permission:PermissionManager.Permissions.Get"]);
            productManagement.AddChild(PermissionPermissions.Permissions.Edit, _localizer["Permission:PermissionManager.Permissions.Edit"]);
        }
    }
}