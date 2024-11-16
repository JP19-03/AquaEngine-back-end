using AquaEngine.API.Sales.Domain.Model.Commands;
using AquaEngine.API.Sales.Interfaces.REST.Resources;


namespace AquaEngine.API.Sales.Interfaces.REST.Transform;

public class CreateInvoiceCommandFromResourceAssembler
{
    public static CreateInvoiceCommand ToCommandFromResource(CreateInvoiceResource resource)
    {
        return new CreateInvoiceCommand( resource.Id ,resource.Name, resource.UrlToImage, resource.Status);
    }
}