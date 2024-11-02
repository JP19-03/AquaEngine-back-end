using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Invoice.Domain.Model.Queries;

namespace AquaEngine.API.Invoice.Domain.Services;

public interface IInvoiceQueryService
{
    //Task<IEnumerable<Invoice>> Handle(GetInvoiceByUserIdQuery query);

    Task<Model.Aggregates.Invoice?> Handle(GetInvoiceByStatus query);

    Task<Model.Aggregates.Invoice?> Handle(GetInvoiceByIdQuery query);
    Task<IEnumerable<Model.Aggregates.Invoice>> Handle(GetAllInvoiceQuery query);
}