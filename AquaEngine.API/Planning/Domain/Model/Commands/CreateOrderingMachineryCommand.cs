namespace AquaEngine.API.Planning.Domain.Model.Commands;

public record CreateOrderingMachineryCommand(int Id, string Name, string UrlToImage, string Status);