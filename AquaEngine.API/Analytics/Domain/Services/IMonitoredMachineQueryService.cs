using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Queries;

namespace AquaEngine.API.Analytics.Domain.Services;

public interface IMonitoredMachineQueryService
{
    Task<IEnumerable<MonitoredMachine>> Handle(GetMonitoredMachineByUserIdQuery query);
    
    Task<MonitoredMachine?> Handle(GetMonitoredMachineByStatus query);
    
    Task<MonitoredMachine?> Handle(GetMonitoredMachineByIdQuery query);
    
}