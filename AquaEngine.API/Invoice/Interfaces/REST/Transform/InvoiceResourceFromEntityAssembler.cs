using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Invoice.Interfaces.REST.Resources;

namespace AquaEngine.API.Invoice.Interfaces.REST.Transform;

public class InvoiceResourceFromEntityAssembler
{
    public static InvoiceResource ToResourceFromEntity(Domain.Model.Aggregates.Invoice entity)
    {
        return new InvoiceResource(entity.Id, entity.Name, entity.UrlToImage, entity.Status);
    } 
}