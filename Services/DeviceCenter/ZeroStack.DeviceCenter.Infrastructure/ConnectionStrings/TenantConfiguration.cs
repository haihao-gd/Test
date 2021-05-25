using System;
using System.Collections.Generic;

namespace ZeroStack.DeviceCenter.Infrastructure.ConnectionStrings
{
    [Serializable]
    public class TenantConfiguration
    {
        public Guid TenantId { get; set; }

        public string TenantName { get; set; } = string.Empty;

        public Dictionary<string, string>? ConnectionStrings { get; set; }
    }
}
