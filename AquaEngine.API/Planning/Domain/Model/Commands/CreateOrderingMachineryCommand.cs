namespace AquaEngine.API.Planning.Domain.Model.Commands;

public record CreateOrderingMachineryCommand(string Id, string Name, string UrlToImage, string Status);