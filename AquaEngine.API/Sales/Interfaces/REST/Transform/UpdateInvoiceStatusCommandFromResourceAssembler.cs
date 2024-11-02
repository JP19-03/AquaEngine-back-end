using AquaEngine.API.Invoice.Domain.Model.Commands;
using AquaEngine.API.Invoice.Interfaces.REST.Resources;

namespace AquaEngine.API.Invoice.Interfaces.REST.Transform;

public class UpdateInvoiceStatusCommandFromResourceAssembler
{
    public static UpdateInvoiceStatusCommand ToCommandFromResource(UpdateInvoiceStatusResource resource)
    {
        return new UpdateInvoiceStatusCommand(resource.Id, resource.Status);
    }
}