namespace AquaEngine.API.Control.Domain.Model.Commands;

public record DecreaseQuantityCommand(int Quantity, long ProductId);