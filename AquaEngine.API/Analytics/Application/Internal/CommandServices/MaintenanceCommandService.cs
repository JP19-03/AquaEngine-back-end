using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Application.Internal.CommandServices;

/// <summary>
/// This class represents the command service for the maintenance entity
/// </summary>
public class MaintenanceCommandService : IMaintenanceCommandService
{
    private readonly IMaintenanceRepository maintenanceRepository;
    private readonly IUnitOfWork unitOfWOrk;

    public MaintenanceCommandService(IMaintenanceRepository maintenanceRepository, IUnitOfWork unitOfWOrk)
    {
        this.maintenanceRepository = maintenanceRepository;
        this.unitOfWOrk = unitOfWOrk;
    }

    public async Task<Maintenance?> Handle(CreateMaintenanceCommand command)
    {
        var maintenance = new Maintenance(command);

        try
        {
            await maintenanceRepository.AddAsync(maintenance);
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return maintenance;
    }
    
    public async Task<Maintenance?> Handle(UpdateMaintenanceCommand command)
    {
        var maintenance = await maintenanceRepository.FindByIdAsync(command.Id);
        if (maintenance == null)
        {
            return null;
        }

        maintenance.Update(command);

        try
        {
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return maintenance;
    }
}