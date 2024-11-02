using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Shared.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Planning.Infrastructure.Persistence.EFC.Repositories;

public class OrderingMachineryRepository(AppDbContext context):
    BaseRepository<OrderingMachinery>(context), IOrderingMachineryRepository
{
    Task<OrderingMachinery?> IBaseRepository<OrderingMachinery>.FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderingMachinery?> FindByStatusAsync(string status)
    {
        return await Context.Set<OrderingMachinery>().FirstOrDefaultAsync(o => o.Status == status);
    }

    Task<OrderingMachinery?> IOrderingMachineryRepository.FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderingMachinery?> FindByNameAndUserIdAsync(string name, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderingMachinery>> FindByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    
}