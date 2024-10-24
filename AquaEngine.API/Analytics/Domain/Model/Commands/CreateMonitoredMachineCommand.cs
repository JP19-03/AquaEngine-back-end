namespace AquaEngine.API.Analytics.Domain.Model.Commands;

public record CreateMonitoredMachineCommand(String Name,String UrlToImage, String Status);