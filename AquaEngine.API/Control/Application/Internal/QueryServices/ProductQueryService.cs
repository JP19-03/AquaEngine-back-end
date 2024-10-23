using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Queries;
using AquaEngine.API.Control.Domain.Repositories;
using AquaEngine.API.Control.Domain.Services;

namespace AquaEngine.API.Control.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public Task<IEnumerable<Product>> handle(GetProducctByUserIdQuery query)
    {
        return productRepository.FindByUserIdAsync(query.UserId.userId);
    }

    public async Task<Product?> handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync((int)query.ProductId);
    }

    public async Task<Product?> handle(GetProductByNameQuery query)
    {
        return await productRepository.FindByNameAsync(query.Name);
    }
}