namespace AquaEngine.API.Control.Interfaces.REST.Resources;

public record CreateProductResource(long UserId, string Name, string QuantityPerUnit, double UnitPrice, int Quantity);