using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Commands;
/// <summary>
/// This record represents the command to create a monitored machine
/// </summary>
/// <param name="UserId"></param>
/// <param name="Name"></param>
/// <param name="UrlToImage"></param>
/// <param name="Status"></param>
public record CreateMonitoredMachineCommand(long UserId,string Name,string UrlToImage, EMachineStatus Status);