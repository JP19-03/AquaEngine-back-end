using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Invoice.Domain.Model.Queries;
using AquaEngine.API.Invoice.Domain.Repositories;
using AquaEngine.API.Invoice.Domain.Services;

namespace AquaEngine.API.Invoice.Application.Internal.QueryServices;

public class InvoiceQueryService(IInvoiceRepository InvoiceRepository) : IInvoiceQueryService
{
    public async Task<Domain.Model.Aggregates.Invoice?> Handle(GetInvoiceByIdQuery query)
    {
        return await InvoiceRepository.FindByIdAsync(query.Id);
    }

    public async Task<Domain.Model.Aggregates.Invoice?> Handle(GetInvoiceByStatus query)
    {
        return await InvoiceRepository.FindByStatusAsync(query.Status);
    }
    
    public async Task<IEnumerable<Domain.Model.Aggregates.Invoice>> Handle(GetAllInvoiceQuery query)
    {
        return await InvoiceRepository.ListAsync();
    }
}