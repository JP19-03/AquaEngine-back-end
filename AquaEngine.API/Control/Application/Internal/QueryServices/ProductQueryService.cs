using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Queries;
using AquaEngine.API.Control.Domain.Repositories;
using AquaEngine.API.Control.Domain.Services;

namespace AquaEngine.API.Control.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public Task<IEnumerable<Product>> Handle(GetProducctByUserIdQuery query)
    {
        return productRepository.FindByUserIdAsync(query.UserId.Id);
    }

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync((int)query.ProductId);
    }

    public async Task<Product?> Handle(GetProductByNameQuery query)
    {
        return await productRepository.FindByNameAsync(query.Name);
    }
}