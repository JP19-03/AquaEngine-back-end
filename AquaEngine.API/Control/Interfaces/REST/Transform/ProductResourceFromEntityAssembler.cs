using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product product)
    {
        return new ProductResource(product.Id, product.UserId.userId, product.Name, product.QuantityPerUnit, product.UnitPrice, product.Quantity);
    }
}