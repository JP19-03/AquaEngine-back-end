using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Interfaces.REST.Resources;

namespace AquaEngine.API.Planning.Interfaces.REST.Transform;

public class UpdateOrderingStatusCommandFromResourceAssembler
{
    public static UpdateOrderingStatusCommand ToCommandFromResource(UpdateOrderingStatusResource resource)
    {
        return new UpdateOrderingStatusCommand(resource.Id, resource.Status);
    }
}