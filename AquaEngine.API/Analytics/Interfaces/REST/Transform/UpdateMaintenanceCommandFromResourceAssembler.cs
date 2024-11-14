using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;

public class UpdateMaintenanceCommandFromResourceAssembler
{
    public static UpdateMaintenanceCommand ToCommandFromResource(UpdateMaintenanceResource resource)
    {
        return new UpdateMaintenanceCommand(resource.Id,resource.MonitoredMachineId,resource.TechnicianName,resource.Description,resource.AdditionalInfo,resource.IssueType);
    }
}