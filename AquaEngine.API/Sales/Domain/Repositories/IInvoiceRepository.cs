using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Invoice.Domain.Repositories;

public interface IInvoiceRepository: IBaseRepository<Model.Aggregates.Invoice>
{
    Task<Model.Aggregates.Invoice?> FindByStatusAsync(string status);
    Task<Model.Aggregates.Invoice?> FindByIdAsync(int id);
    Task<Model.Aggregates.Invoice?> FindByNameAndUserIdAsync(string name, long userId);
    Task<IEnumerable<Model.Aggregates.Invoice>> FindByUserIdAsync(long userId);
}