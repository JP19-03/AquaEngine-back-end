using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Domain.Model.Commands;
using AquaEngine.API.Sales.Domain.Repositories;
using AquaEngine.API.Sales.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Sales.Application.Internal.CommandServices;

public class InvoiceCommandService (IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
: IInvoiceCommandService
{
    public async Task<Invoice?> Handle(CreateInvoiceCommand command)
    {
        var invoice = new Invoice(command);
        try
        {
            await invoiceRepository.AddAsync(invoice);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return invoice;
    }
    public async Task<Invoice?> Handle(UpdateInvoiceStatusCommand command)
    {
        var invoice = await invoiceRepository.FindByIdAsync((int)command.Id);
        
        if (invoice == null)
            throw new ArgumentException("Invoice not found");

        try
        {
            invoice.UpdateStatus(command);
            invoiceRepository.Update(invoice);
            await unitOfWork.CompleteAsync();

            return invoice;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}