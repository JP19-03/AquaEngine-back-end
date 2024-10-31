using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Planning.Domain.Repositories;

public interface IOrderingMachineryRepository: IBaseRepository<OrderingMachinery>
{
    Task<OrderingMachinery?> FindByStatusAsync(string status);
    Task<OrderingMachinery?> FindByIdAsync(int id);
    Task<OrderingMachinery?> FindByNameAndUserIdAsync(string name, long userId);
    Task<IEnumerable<OrderingMachinery>> FindByUserIdAsync(long userId);
}