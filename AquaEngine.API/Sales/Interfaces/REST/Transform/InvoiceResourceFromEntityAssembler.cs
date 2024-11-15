using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Interfaces.REST.Resources;

namespace AquaEngine.API.Sales.Interfaces.REST.Transform;

public class InvoiceResourceFromEntityAssembler
{
    public static InvoiceResource ToResourceFromEntity(Sales.Domain.Model.Aggregates.Invoice entity)
    {
        return new InvoiceResource(entity.Id, entity.Name, entity.UrlToImage, entity.Status);
    } 
}