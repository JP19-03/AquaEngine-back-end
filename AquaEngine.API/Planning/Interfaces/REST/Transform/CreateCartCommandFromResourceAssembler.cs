using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Interfaces.REST.Resources;

namespace AquaEngine.API.Planning.Interfaces.REST.Transform;

public static class CreateCartCommandFromResourceAssembler
{
    public static CreateCartCommand ToCommandFromResource(CreateCartResource resource)
    {
        return new CreateCartCommand(resource.Name, resource.UrlToImage);
    }
}