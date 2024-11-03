using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.UserId, resource.Name, resource.QuantityPerUnit, resource.UnitPrice, resource.Quantity);
    }
}