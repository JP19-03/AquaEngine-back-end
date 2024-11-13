using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;

namespace AquaEngine.API.Analytics.Interfaces.REST.Transform;
/// <summary>
/// This class is responsible for transforming a DeleteMonitoredMachineResource into a DeleteMonitoredMachineCommand
/// </summary>
public class DeleteMonitoredMachineCommandFromResourceAssembler
{
    /// <summary>
    /// This method transforms a DeleteMonitoredMachineResource into a DeleteMonitoredMachineCommand
    /// </summary>
    /// <param name="resource"> <see cref="DeleteMonitoredMachineResource"/> </param>
    /// <returns>
    /// <see cref="DeleteMonitoredMachineCommand"/>
    /// </returns>
    public static DeleteMonitoredMachineCommand ToCommandFromResource(DeleteMonitoredMachineResource resource)
    {
        return new DeleteMonitoredMachineCommand(resource.Id);
    }
}