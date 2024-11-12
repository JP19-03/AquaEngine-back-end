using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Commands;

public record CreateMonitoredMachineCommand(long UserId,string Name,string UrlToImage, EMachineStatus Status);