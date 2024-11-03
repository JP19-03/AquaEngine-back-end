using AquaEngine.API.Invoice.Domain.Model.Commands;
using AquaEngine.API.Invoice.Interfaces.REST.Resources;

namespace AquaEngine.API.Invoice.Interfaces.REST.Transform;

public class CreateInvoiceCommandFromResourceAssembler
{
    public static CreateInvoiceCommand ToCommandFromResource(CreateInvoiceResource resource)
    {
        return new CreateInvoiceCommand( resource.Id ,resource.Name, resource.UrlToImage, resource.Status);
    }
}