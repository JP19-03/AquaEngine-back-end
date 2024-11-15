using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Interfaces.REST.Resources;

namespace AquaEngine.API.Planning.Interfaces.REST.Transform;

public class CreateOrderingMachineryCommandFromResourceAssembler
{
    public static CreateOrderingMachineryCommand ToCommandFromResource(CreateOrderingMachineryResource resource)
    {
        return new CreateOrderingMachineryCommand( resource.Id ,resource.Name, resource.UrlToImage, resource.Status, resource.EStockAspect);
    }
}