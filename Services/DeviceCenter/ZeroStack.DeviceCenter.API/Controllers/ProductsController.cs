using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Models.Generics;
using ZeroStack.DeviceCenter.Application.Models.Products;
using ZeroStack.DeviceCenter.Application.PermissionProviders;
using ZeroStack.DeviceCenter.Application.Services.Products;

namespace ZeroStack.DeviceCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplicationService _productService;

        public ProductsController(IProductApplicationService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[Authorize(ProductPermissions.Products.Default)]
        public async Task<PagedResponseModel<ProductGetResponseModel>> GetProducts([FromQuery] ProductPagedRequestModel model)
        {
            return await _productService.GetListAsync(model);
        }

        [HttpGet("{id}")]
        //[Authorize(ProductPermissions.Products.Default)]
        public async Task<ProductGetResponseModel> GetProduct(Guid id)
        {
            return await _productService.GetAsync(id);
        }

        [HttpPost]
        [Authorize(ProductPermissions.Products.Create)]
        public async Task<ProductGetResponseModel> PostProduct([FromBody] ProductCreateOrUpdateRequestModel value)
        {
            return await _productService.CreateAsync(value);
        }

        [HttpPut("{id}")]
        [Authorize(ProductPermissions.Products.Edit)]
        public async Task<ProductGetResponseModel> PutProduct(Guid id, [FromBody] ProductCreateOrUpdateRequestModel value)
        {
            value.Id = id;
            return await _productService.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        [Authorize(ProductPermissions.Products.Delete)]
        public async Task DeleteProduct(Guid id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
