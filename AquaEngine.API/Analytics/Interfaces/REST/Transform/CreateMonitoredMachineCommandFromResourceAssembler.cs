using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;

public class CreateMonitoredMachineCommandFromResourceAssembler
{
    public static CreateMonitoredMachineCommand ToCommandFromResource(CreateMonitoredMachineResource resource)
    {
        return new CreateMonitoredMachineCommand(resource.UserId, resource.Name, resource.UrlToImage, resource.Status);
        
    }
}