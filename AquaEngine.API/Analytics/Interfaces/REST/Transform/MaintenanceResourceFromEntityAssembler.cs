using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;

public class MaintenanceResourceFromEntityAssembler
{
    public static MaintenanceResource ToResourceFromEntity(Maintenance maintenance)
    {
        return new MaintenanceResource(maintenance.Id,maintenance.MonitoredMachineId,maintenance.TechnicianName,maintenance.Description,maintenance.AdditionalInfo,maintenance.IssueType);
    }
}