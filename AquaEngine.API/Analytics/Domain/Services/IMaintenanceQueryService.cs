using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Queries;

namespace AquaEngine.API.Analytics.Domain.Services;

public interface IMaintenanceQueryService
{
    Task<IEnumerable<Maintenance>> Handle(GetMaintenanceByMachineIdQuery query);
    
    Task<Maintenance?> Handle(GetMaintenanceByIssueTypeQuery query);
    
    Task<Maintenance?> Handle(GetMaintenanceByIdQuery query);

    Task<IEnumerable<Maintenance>> Handle(GetAllMaintenance query);
}