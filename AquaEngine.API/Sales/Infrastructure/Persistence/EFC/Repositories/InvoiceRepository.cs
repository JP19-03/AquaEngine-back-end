
using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Domain.Repositories;
using AquaEngine.API.Shared.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Sales.Infrastructure.Persistence.EFC.Repositories;

public class InvoiceRepository(AppDbContext context):
    BaseRepository<Domain.Model.Aggregates.Invoice>(context), IInvoiceRepository
{
    Task<Domain.Model.Aggregates.Invoice?> IBaseRepository<Domain.Model.Aggregates.Invoice>.FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    
    public Task<Invoice?> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Aggregates.Invoice?> FindByNameAndUserIdAsync(string name, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Model.Aggregates.Invoice>> FindByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    
}