namespace AquaEngine.API.Analytics.Interfaces.REST.Resources;
/// <summary>
/// This record represents the resource to delete a monitored machine
/// </summary>
/// <param name="Id"> The machine identifier </param>
public record DeleteMonitoredMachineResource(int Id);