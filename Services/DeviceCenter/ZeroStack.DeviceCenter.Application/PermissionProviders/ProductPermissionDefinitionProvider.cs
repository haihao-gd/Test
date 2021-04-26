using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Services.Permissions;

namespace ZeroStack.DeviceCenter.Application.PermissionProviders
{
    public class ProductPermissionDefinitionProvider : IPermissionDefinitionProvider
    {
        private readonly IStringLocalizer _localizer;

        public ProductPermissionDefinitionProvider(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Welcome", Assembly.GetExecutingAssembly().FullName ?? string.Empty);
        }

        public void Define(PermissionDefinitionContext context)
        {
            var productGroup = context.AddGroup(ProductPermissions.GroupName, _localizer["Permission:ProductManager"]);

            var productManagement = productGroup.AddPermission(ProductPermissions.Products.Default, _localizer["Permission:ProductStore.Products"]);

            productManagement.AddChild(ProductPermissions.Products.Create, _localizer["Permission:ProductManager.Products.Creeate"]);
            productManagement.AddChild(ProductPermissions.Products.Edit, _localizer["Permission:ProductManager.Products.Edit"]);
            productManagement.AddChild(ProductPermissions.Products.Delete, _localizer["Permission:ProductManager.Products.Delete"]);
        }
    }
}
