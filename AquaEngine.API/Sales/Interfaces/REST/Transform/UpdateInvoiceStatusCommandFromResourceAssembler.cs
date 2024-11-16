using AquaEngine.API.Sales.Domain.Model.Commands;
using AquaEngine.API.Sales.Interfaces.REST.Resources;

namespace AquaEngine.API.Sales.Interfaces.REST.Transform;

public class UpdateInvoiceStatusCommandFromResourceAssembler
{
    public static UpdateInvoiceStatusCommand ToCommandFromResource(UpdateInvoiceStatusResource resource)
    {
        return new UpdateInvoiceStatusCommand(resource.Id, resource.Status);
    }
}