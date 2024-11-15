using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Queries;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;

namespace AquaEngine.API.Analytics.Application.Internal.QueryServices;

public class MaintenanceQueryService(IMaintenanceRepository maintenanceRepository):IMaintenanceQueryService
{
    public  async Task<IEnumerable<Maintenance>> Handle(GetMaintenanceByMachineIdQuery query)
    {
        return await maintenanceRepository.FindByMonitoredMachineIdAsync(query.MachineId.Id);
    }

    public  async Task<Maintenance?> Handle(GetMaintenanceByIssueTypeQuery query)
    {
        return  await maintenanceRepository.FindByIssueTypeAsync(query.IssueType);
    }

    public  async Task<Maintenance?> Handle(GetMaintenanceByIdQuery query)
    {
        return await maintenanceRepository.FindByIdAsync(query.Id);
        
    }

    public async Task<IEnumerable<Maintenance>> Handle(GetAllMaintenance query)
    {
        return await maintenanceRepository.ListAsync();
    }
}