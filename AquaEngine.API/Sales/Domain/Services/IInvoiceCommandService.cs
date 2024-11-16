using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Domain.Model.Commands;

namespace AquaEngine.API.Sales.Domain.Services;

public interface IInvoiceCommandService
{
    Task<Model.Aggregates.Invoice?> Handle(CreateInvoiceCommand command);
    Task<Invoice?> Handle(UpdateInvoiceStatusCommand command);
  
}