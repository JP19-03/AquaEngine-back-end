
using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Sales.Domain.Repositories;

public interface IInvoiceRepository: IBaseRepository<Model.Aggregates.Invoice>
{
    
    new Task<Invoice?> FindByIdAsync(long id);
    Task<Model.Aggregates.Invoice?> FindByNameAndUserIdAsync(string name, long userId);
    Task<IEnumerable<Model.Aggregates.Invoice>> FindByUserIdAsync(long userId);
}