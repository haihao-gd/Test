using System;
using System.Threading.Tasks;
using ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate;
using ZeroStack.DeviceCenter.Domain.Repositories;

namespace ZeroStack.DeviceCenter.Domain.Services.Products
{
    public class ProductDataSeedProvider : IDataSeedProvider
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductDataSeedProvider(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            if (await _productRepository.GetCountAsync() <= 0)
            {
                for (int i = 1; i < 30; i++)
                {
                    Guid? tenantId = null;

                    if (i >= 10 && i < 20)
                    {
                        tenantId = Guid.Parse($"f30e402b-9de2-4b48-9ff0-c073cf499102");
                    }

                    if (i >= 20 && i < 30)
                    {
                        tenantId = Guid.Parse($"f30e402b-9de2-4b48-9ff0-c073cf499103");
                    }

                    var product = new Product { Name = $"Product{i.ToString().PadLeft(2, '0')}", TenantId = tenantId };
                    await _productRepository.InsertAsync(product, true);
                }
            }
        }

    }
}
