using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Commands;
/// <summary>
/// This command is used to update the status of a monitored machine 
/// </summary>
/// <param name="Id">The ID of the monitored machine</param>
/// <param name="Status">The status of the monitored machine</param>
public record UpdateMonitoringStatusCommand(int Id, EMachineStatus Status);