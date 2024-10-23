namespace AquaEngine.API.Control.Interfaces.REST.Resources;

public record ProductResource(
    long Id,
    long UserId,
    string Name,
    string QuantityPerUnit,
    double UnitPrice,
    int Quantity
    );