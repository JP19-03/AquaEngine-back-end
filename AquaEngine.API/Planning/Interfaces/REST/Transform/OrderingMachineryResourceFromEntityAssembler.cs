using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Interfaces.REST.Resources;

namespace AquaEngine.API.Planning.Interfaces.REST.Transform;

public class OrderingMachineryResourceFromEntityAssembler
{
    public static OrderingMachineryResource ToResourceFromEntity(OrderingMachinery entity)
    {
        return new OrderingMachineryResource(entity.Id, entity.Name, entity.UrlToImage, entity.Status);
    } 
}