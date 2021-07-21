using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ZeroStack.DeviceCenter.Application.Models.Permissions
{
    public class PermissionGroupModel
    {
        public string Name { get; set; } = null!;

        public string? DisplayName { get; set; }

        public List<PermissionGrantModel> Permissions { get; set; } = null!;
    }
}
