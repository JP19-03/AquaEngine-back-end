namespace AquaEngine.API.Control.Domain.Model.Commands;

public record IncreaseQuantityCommand(int Quantity, long ProductId);