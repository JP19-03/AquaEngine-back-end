namespace AquaEngine.API.Control.Domain.Model.Commands;

public record CreateProductCommand(long UserId, string Name, string QuantityPerUnit, double UnitPrice, int Quantity);