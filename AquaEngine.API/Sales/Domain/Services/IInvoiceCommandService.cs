using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Invoice.Domain.Model.Commands;

namespace AquaEngine.API.Invoice.Domain.Services;

public interface IInvoiceCommandService
{
    Task<Model.Aggregates.Invoice?> Handle(CreateInvoiceCommand command);
    Task<Model.Aggregates.Invoice> Handle(UpdateInvoiceStatusCommand command);
}