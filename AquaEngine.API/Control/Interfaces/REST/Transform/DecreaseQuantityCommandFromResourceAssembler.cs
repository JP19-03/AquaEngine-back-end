using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class DecreaseQuantityCommandFromResourceAssembler
{
    public static DecreaseQuantityCommand ToCommandFromResource(DecreaseQuantityResource resource)
    {
        return new DecreaseQuantityCommand(resource.Quantity, (int)resource.ProductId);
    }
}