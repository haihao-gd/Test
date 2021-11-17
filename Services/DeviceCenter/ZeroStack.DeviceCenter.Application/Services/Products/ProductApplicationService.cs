using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Application.Models.Products;
using ZeroStack.DeviceCenter.Application.Services.Generics;
using ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate;
using ZeroStack.DeviceCenter.Domain.Repositories;

namespace ZeroStack.DeviceCenter.Application.Services.Products
{
    public class ProductApplicationService : CrudApplicationService<Product, Guid, ProductGetResponseModel, ProductPagedRequestModel, ProductGetResponseModel, ProductCreateOrUpdateRequestModel, ProductCreateOrUpdateRequestModel>, IProductApplicationService
    {
        public ProductApplicationService(IRepository<Product, Guid> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        protected override IQueryable<Product> CreateFilteredQuery(ProductPagedRequestModel requestModel)
        {
            if (requestModel.Keyword is not null && !string.IsNullOrWhiteSpace(requestModel.Keyword))
            {
                return Repository.Query.Where(e => e.Name.Contains(requestModel.Keyword));
            }

            return base.CreateFilteredQuery(requestModel);
        }

        public async Task<Product> GetByName(string productName)
        {
            return await Repository.GetAsync(p => p.Name == productName);
        }

        public async Task<Product> GetProductForRelated()
        {
            Product product = await Repository.GetAsync(Guid.NewGuid(), false);

            await Repository.LoadRelatedAsync(product, e => e.Devices);
            await Repository.LoadRelatedAsync(product, e => e.Name);

            product = (await Repository.IncludeRelatedAsync(e => e.Devices!, e => e.Name)).Where(e => e.Id == Guid.NewGuid()).First();

            return product;
        }
    }
}
