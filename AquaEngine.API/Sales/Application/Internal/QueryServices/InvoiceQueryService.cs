
using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Domain.Model.Queries;
using AquaEngine.API.Sales.Domain.Repositories;
using AquaEngine.API.Sales.Domain.Services;

namespace AquaEngine.API.Sales.Application.Internal.QueryServices;

public class InvoiceQueryService(IInvoiceRepository invoiceRepository) : IInvoiceQueryService
{
    public Task<IEnumerable<Invoice>> Handle(GetInvoiceByUserIdQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Model.Aggregates.Invoice?> Handle(GetInvoiceByIdQuery query)
    {
        return await invoiceRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Domain.Model.Aggregates.Invoice>> Handle(GetAllInvoiceQuery query)
    {
        return await invoiceRepository.ListAsync();
    }
}