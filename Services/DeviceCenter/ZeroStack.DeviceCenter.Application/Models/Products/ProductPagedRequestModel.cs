using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Models.Generics;

namespace ZeroStack.DeviceCenter.Application.Models.Products
{
    public class ProductPagedRequestModel: PagedRequestModel
    {
        public string? Keyword { get; set; }
    }
}
