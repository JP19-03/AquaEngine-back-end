using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Commands;

namespace AquaEngine.API.Analytics.Domain.Services;

public interface IMaintenanceCommandService
{
    Task<Maintenance?> Handle(CreateMaintenanceCommand command);
    Task<Maintenance?> Handle(UpdateMaintenanceCommand command);
}