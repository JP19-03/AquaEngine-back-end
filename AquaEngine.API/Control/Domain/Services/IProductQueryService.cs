using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Queries;

namespace AquaEngine.API.Control.Domain.Services;

public interface IProductQueryService
{
    Task<List<Product>> handle(GetProducctByUserIdQuery query);
    Task<Product?> handle(GetProductByIdQuery query);
    Task<Product?> handle(GetProductByNameQuery query);
}