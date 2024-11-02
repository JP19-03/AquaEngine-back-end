namespace AquaEngine.API.Analytics.Interfaces.REST.Resources;

public record MonitoredMachineResource(int Id, long UserId, string Name, string UrlToImage, string Status);