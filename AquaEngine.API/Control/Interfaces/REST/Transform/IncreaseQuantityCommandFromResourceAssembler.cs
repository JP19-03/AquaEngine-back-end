using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class IncreaseQuantityCommandFromResourceAssembler
{
    public static IncreaseQuantityResource ToCommandFromResource(IncreaseQuantityResource resource)
    {
        return new IncreaseQuantityResource(resource.Quantity, (int)resource.ProductId);
    }
}