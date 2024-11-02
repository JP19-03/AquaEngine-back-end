using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class UpdateProductOwnerCommandFromResourceAssembler
{
    public static UpdateProductOwnerCommand ToCommandFromResource(UpdateProductOwnerResource resource)
    {
        return new UpdateProductOwnerCommand(resource.ProductId, resource.UserId);
    }
}