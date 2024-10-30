namespace AquaEngine.API.Analytics.Interfaces.REST.Resources;

public record CreateMonitoredMachineResource(long UserId, string Name, string UrlToImage, string Status);
