using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class MonitoredMachineRepository(AppDbContext context):
    BaseRepository<MonitoredMachine>(context), IMonitoredMachineRepository
{
    public async Task<MonitoredMachine?> FindByStatusAsync(string status)
    {
        return await Context.Set<MonitoredMachine>().FirstOrDefaultAsync(m => m.Status == status);
    }

    public async Task<MonitoredMachine?> FindByNameAndUserIdAsync(string name, long userId)
    {
        return await Context.Set<MonitoredMachine>().FirstOrDefaultAsync(m => m.Name == name && m.UserId == userId);
    }

    public async Task<IEnumerable<MonitoredMachine>> FindByUserIdAsync(long userId)
    {
        //If the aggregate cannot be returned an awaitable object, use ToListAsync() instead of ToList()
        return await Context.Set<MonitoredMachine>().Where(m => m.UserId == userId).ToListAsync();
    }
}