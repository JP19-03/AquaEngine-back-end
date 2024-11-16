using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Interfaces.REST.Resources;

namespace AquaEngine.API.Planning.Interfaces.REST.Transform;

public static class DeleteCartCommandFromResourceAssembler
{
    public static DeleteCartCommand ToCommandFromResource(DeleteCartResource resource)
    {
        return new DeleteCartCommand(resource.Id);
    }
}