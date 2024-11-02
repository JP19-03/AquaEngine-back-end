using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Commands;

namespace AquaEngine.API.Analytics.Domain.Services;

public interface IMonitoredMachineCommandService
{
    Task<MonitoredMachine> Handle(CreateMonitoredMachineCommand command);
    Task<MonitoredMachine> Handle(UpdateMonitoringStatusCommand command);
    
}