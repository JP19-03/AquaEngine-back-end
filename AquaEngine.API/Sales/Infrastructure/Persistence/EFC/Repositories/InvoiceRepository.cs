using AquaEngine.API.Invoice.Domain.Model.Aggregates;
using AquaEngine.API.Invoice.Domain.Repositories;
using AquaEngine.API.Shared.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Invoice.Infrastructure.Persistence.EFC.Repositories;

public class InvoiceRepository(AppDbContext context):
    BaseRepository<Domain.Model.Aggregates.Invoice>(context), IInvoiceRepository
{
    Task<Domain.Model.Aggregates.Invoice?> IBaseRepository<Domain.Model.Aggregates.Invoice>.FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Model.Aggregates.Invoice?> FindByStatusAsync(string status)
    {
        return await Context.Set<Domain.Model.Aggregates.Invoice>().FirstOrDefaultAsync(o => o.Status == status);
    }

    Task<Domain.Model.Aggregates.Invoice?> IInvoiceRepository.FindByIdAsync(int id)
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