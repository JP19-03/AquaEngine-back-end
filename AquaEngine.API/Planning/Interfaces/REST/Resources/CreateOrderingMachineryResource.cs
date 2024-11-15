using AquaEngine.API.Planning.Domain.Model.ValueObjects;

namespace AquaEngine.API.Planning.Interfaces.REST.Resources;

public record CreateOrderingMachineryResource(int Id, string Name, string UrlToImage, string Status, StockAspect StockAspect);