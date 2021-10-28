using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroStack.DeviceCenter.Application.Services.Generics
{
    public enum SortingOrder { Ascending, Descending }

    public class SortingDescriptor
    {
        [AllowNull]
        public string PropertyName { get; set; }

        public SortingOrder SortDirection { get; set; }
    }
}
