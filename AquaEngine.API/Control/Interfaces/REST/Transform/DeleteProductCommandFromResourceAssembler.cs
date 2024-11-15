using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class DeleteProductCommandFromResourceAssembler
{
    public static DeleteProductCommand ToCommandFromResource(DeleteProductResource resource)
    {
        return new DeleteProductCommand(resource.Id);
    }
}