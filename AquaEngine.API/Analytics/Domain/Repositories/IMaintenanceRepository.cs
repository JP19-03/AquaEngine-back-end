using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Domain.Repositories;

public interface IMaintenanceRepository: IBaseRepository<Maintenance>
{
    Task<Maintenance?> FindByIssueTypeAsync(string issueType);
    Task<Maintenance?> FindByIdAsync(int id);
    Task<IEnumerable<Maintenance>> FindByMonitoredMachineIdAsync(int monitoredMachineId);
    
}