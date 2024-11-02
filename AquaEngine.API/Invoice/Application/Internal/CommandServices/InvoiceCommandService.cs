using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Invoice.Domain.Model.Commands;
using AquaEngine.API.Invoice.Domain.Repositories;
using AquaEngine.API.Invoice.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Invoice.Application.Internal.CommandServices;

public class InvoiceCommandService (IInvoiceRepository InvoiceRepository, IUnitOfWOrk unitOfWork)
: IInvoiceCommandService
{
    public async Task<Domain.Model.Aggregates.Invoice?> Handle(CreateInvoiceCommand command)
    {
        var Invoice = new Domain.Model.Aggregates.Invoice(command);
        try
        {
            await InvoiceRepository.AddAsync(Invoice);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return Invoice;
    }
    public async Task<Domain.Model.Aggregates.Invoice> Handle(UpdateInvoiceStatusCommand command)
    {
        var Invoice = await InvoiceRepository.FindByIdAsync((int)command.Id);
        
        if (Invoice == null)
            throw new ArgumentException("Invoice not found");

        try
        {
            Invoice.UpdateStatus(command);
            InvoiceRepository.Update(Invoice);
            await unitOfWork.CompleteAsync();

            return Invoice;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}