namespace AquaEngine.API.Analytics.Domain.Model.Queries;

public record GetMonitoredMachineByNameAndUserIdQuery(string Name, long UserId);