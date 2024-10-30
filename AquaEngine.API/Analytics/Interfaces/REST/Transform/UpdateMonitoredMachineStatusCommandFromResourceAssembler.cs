using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;

public class UpdateMonitoredMachineStatusCommandFromResourceAssembler
{
    public static UpdateMonitoringStatusCommand ToCommandFromResource(UpdateMonitoredMachineStatusResource resource)
    {
        return new UpdateMonitoringStatusCommand(resource.Id, resource.Status);
    }
    
}