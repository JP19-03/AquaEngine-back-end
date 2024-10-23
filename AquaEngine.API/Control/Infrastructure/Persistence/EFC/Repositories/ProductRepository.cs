using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.ValueObjects;
using AquaEngine.API.Control.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Control.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) 
    : BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product?> FindByNameAsync(string name)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Product>> FindByUserIdAsync(long userId)
    {
        return await Context.Set<Product>().Where(p => p.UserId == userId).ToListAsync();
    }
}