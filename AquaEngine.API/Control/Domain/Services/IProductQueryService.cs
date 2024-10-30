using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Queries;

namespace AquaEngine.API.Control.Domain.Services;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> Handle(GetProducctByUserIdQuery query);
    Task<Product?> Handle(GetProductByIdQuery query);
    Task<Product?> Handle(GetProductByNameQuery query);
}