using ZeroStack.DeviceCenter.Application.Models.Generics;

namespace ZeroStack.DeviceCenter.Application.Models.Products
{
    public class ProductPagedRequestModel : PagedRequestModel
    {
        public string? Keyword { get; set; }
    }
}
