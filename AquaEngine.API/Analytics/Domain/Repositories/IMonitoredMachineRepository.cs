using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Domain.Repositories;

public interface IMonitoredMachineRepository: IBaseRepository<MonitoredMachine>
{
    Task<MonitoredMachine?>FindByStatusAsync(string status); 
    Task<MonitoredMachine?> FindByIdAsync(int id);
    Task<MonitoredMachine?> FindByNameAndUserIdAsync(string name, long userId);
    Task<IEnumerable<MonitoredMachine>> FindByUserIdAsync(long userId);
}