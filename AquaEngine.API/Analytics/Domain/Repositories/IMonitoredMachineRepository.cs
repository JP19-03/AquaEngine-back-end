using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Domain.Repositories;

public interface IMonitoredMachineRepository: IBaseRepository<MonitoredMachine>
{
    Task<MonitoredMachine?>FindByStatusAsync(string status); 
    Task<MonitoredMachine?> FindByIdAsync(int id);
    //TODO IMPLEMENTA EL FIND BY NAME AND USER ID PARA VALIDAR QUE NO HAYAN DOS PRODUCTOS IGUALES
    Task<MonitoredMachine?> FindByNameAndUserIdAsync(string name, long userId);
    Task<IEnumerable<MonitoredMachine>> FindByUserIdAsync(long userId);
}