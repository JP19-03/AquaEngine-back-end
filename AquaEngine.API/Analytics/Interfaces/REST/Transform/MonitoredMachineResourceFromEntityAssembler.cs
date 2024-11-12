using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;

public class MonitoredMachineResourceFromEntityAssembler
{
    public static MonitoredMachineResource ToResourceFromEntity(MonitoredMachine machine)
    {
        return new MonitoredMachineResource(machine.Id, machine.UserId, machine.Name, machine.UrlToImage, machine.Status.ToString());
    }
}