using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class MaintenanceRepository(AppDbContext context):
    BaseRepository<Maintenance>(context), IMaintenanceRepository
{
    public async  Task<Maintenance?> FindByIssueTypeAsync(string issueType)
    {
        return await Context.Set<Maintenance>().FirstOrDefaultAsync(m=>m.IssueType==issueType);   
    }

    public  async Task<IEnumerable<Maintenance>> FindByMonitoredMachineIdAsync(int monitoredMachineId)
    {
        return await Context.Set<Maintenance>().Where(m=>m.MonitoredMachineId==monitoredMachineId).ToListAsync();
    }
    
    public async Task<Maintenance?> FindByIdAsync(int id)
    {
        return await Context.Set<Maintenance>().FirstOrDefaultAsync(m=>m.Id==id);
    }
    
}