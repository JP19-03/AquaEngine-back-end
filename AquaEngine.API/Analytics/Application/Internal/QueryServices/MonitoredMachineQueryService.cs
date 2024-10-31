using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Queries;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;

namespace AquaEngine.API.Analytics.Application.Internal.QueryServices;

public class MonitoredMachineQueryService(IMonitoredMachineRepository monitoredMachineRepository): IMonitoredMachineQueryService
{
    public Task<IEnumerable<MonitoredMachine>> Handle(GetMonitoredMachineByUserIdQuery query)
    {
        return monitoredMachineRepository.FindByUserIdAsync(query.UserId.Id);
    }

    public Task<MonitoredMachine?> Handle(GetMonitoredMachineByStatus query)
    {
        return monitoredMachineRepository.FindByStatusAsync(query.Status);
    }

    public Task<MonitoredMachine?> Handle(GetMonitoredMachineByIdQuery query)
    {
        return monitoredMachineRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<MonitoredMachine>> Handle(GetAllMonitoredMachinesQuery query)
    {
        return await monitoredMachineRepository.ListAsync();
    }
}