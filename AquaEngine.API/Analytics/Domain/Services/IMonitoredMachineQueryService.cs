using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Queries;

namespace AquaEngine.API.Analytics.Domain.Services;

public interface IMonitoredMachineQueryService
{
    Task<IEnumerable<MonitoredMachine>> Handle(GetMonitoredMachineByUserIdQuery query);
    
    Task<MonitoredMachine?> Handle(GetMonitoredMachineByStatus query);
    
    Task<MonitoredMachine?> Handle(GetMonitoredMachineByIdQuery query);

    /// <summary>
    /// Handles the get all monitored machines query in the Aqua Engine monitoring feature
    /// </summary>
    /// <param name="query"></param>
    /// <returns>
    /// A collection of  monitored machines in the platform.
    /// </returns>
    Task<IEnumerable<MonitoredMachine>> Handle(GetAllMonitoredMachinesQuery query);
    
}