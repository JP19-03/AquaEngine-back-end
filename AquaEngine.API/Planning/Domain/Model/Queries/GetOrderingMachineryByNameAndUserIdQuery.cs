namespace AquaEngine.API.Planning.Domain.Model.Queries;

public record GetOrderingMachineryByNameAndUserIdQuery(string Name, long UserId);