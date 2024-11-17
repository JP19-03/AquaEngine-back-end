using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Interfaces.REST.Resources;

namespace AquaEngine.API.Sales.Interfaces.REST.Transform;

public class InvoiceResourceFromEntityAssembler
{
    public static InvoiceResource ToResourceFromEntity(Invoice entity)
    {
        return new InvoiceResource(entity.Id, entity.Client, entity.Product, entity.Quantity, entity.Price, entity.Total, entity.Date);
    } 
}