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
}