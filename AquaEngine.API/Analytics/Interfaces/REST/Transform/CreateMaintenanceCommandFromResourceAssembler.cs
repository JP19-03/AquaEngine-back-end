using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;

public class CreateMaintenanceCommandFromResourceAssembler
{
    public static CreateMaintenanceCommand ToCommandFromResource(CreateMaintenanceResource resource)
    {
        return new CreateMaintenanceCommand(resource.MonitoredMachineId, resource.Technician, resource.IssueType, resource.Description, resource.AdditionalInfo);
        
    }
}