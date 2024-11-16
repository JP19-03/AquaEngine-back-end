using AquaEngine.API.Planning.Domain.Model.Entities;
using AquaEngine.API.Planning.Interfaces.REST.Resources;

namespace AquaEngine.API.Planning.Interfaces.REST.Transform;

public static class CartResourceFromEntityAssembler
{

    public static CartResource ToResourceFromEntity(Cart entity)
    {
        return new CartResource(entity.Id, entity.Name, entity.UrlToImage);
    }
}