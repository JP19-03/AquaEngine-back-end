using AquaEngine.API.Analytics.Domain.Model.ValueObjects;
using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Interfaces.REST.Resources;

namespace AquaEngine.API.Control.Interfaces.REST.Transform;

public class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product product)
    {
        return new ProductResource(product.Id, new UserId(product.UserId), product.Name, product.QuantityPerUnit, product.UnitPrice, product.Quantity);
    }
}