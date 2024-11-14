using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Application.Internal.CommandServices;
/// <summary>
/// This class represents the command service for the maintenance entity
/// </summary>
/// <param name="maintenanceRepository"></param>
/// <param name="unitOfWOrk"></param>
public class MaintenanceCommandService(IMaintenanceRepository maintenanceRepository,IUnitOfWork unitOfWOrk)
:IMaintenanceCommandService
{
    public  async Task<Maintenance?> Handle(CreateMaintenanceCommand command)
    {
        //Considere hacer validaciones pero maitenance puede registrar dos mantenimientos hechos por un solo tecnico o dos mantenimientos por el mismo error, en este caso no necesita
        
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
    
    
}