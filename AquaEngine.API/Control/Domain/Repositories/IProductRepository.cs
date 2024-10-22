using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Control.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> FindByNameAsync(string name);
    Task<IEnumerable<Product>> FindByUserIdAsync(long UserId);
}