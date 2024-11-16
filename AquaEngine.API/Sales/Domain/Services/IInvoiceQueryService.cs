using AquaEngine.API.Sales.Domain.Model.Queries;

namespace AquaEngine.API.Sales.Domain.Services;

public interface IInvoiceQueryService
{
    //Task<IEnumerable<Invoice>> Handle(GetInvoiceByUserIdQuery query);

    Task<Model.Aggregates.Invoice?> Handle(GetInvoiceByStatus query);

    Task<Model.Aggregates.Invoice?> Handle(GetInvoiceByIdQuery query);
    Task<IEnumerable<Model.Aggregates.Invoice>> Handle(GetAllInvoiceQuery query);
}