using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Domain.Repositories;

public interface IMonitoredMachineRepository: IBaseRepository<MonitoredMachine>
{
    Task<MonitoredMachine?>FindByStatusAsync(string status); 
    Task<IEnumerable<MonitoredMachine>> FindByUserIdAsync(long userId);
}