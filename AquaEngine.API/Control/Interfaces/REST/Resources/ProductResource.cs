using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Control.Interfaces.REST.Resources;

public record ProductResource(
    long Id,
    UserId UserId,
    string Name,
    string QuantityPerUnit,
    double UnitPrice,
    int Quantity
    );