using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Shared.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace AquaEngine.API.Planning.Infrastructure.Persistence.EFC.Repositories;

public class OrderingMachineryRepository(AppDbContext context):
    BaseRepository<OrderingMachinery>(context), IOrderingMachineryRepository
{
    Task<OrderingMachinery?> IBaseRepository<OrderingMachinery>.FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderingMachinery?> FindByStatusAsync(string status)
    {
        throw new NotImplementedException();
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