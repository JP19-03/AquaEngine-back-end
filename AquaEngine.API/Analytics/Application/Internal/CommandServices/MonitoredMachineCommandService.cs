using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Analytics.Application.Internal.CommandServices;
/// <summary>
/// This class represents the command service for the monitored machine entity
/// </summary>
/// <param name="monitoredMachineRepository"></param>
/// <param name="unitOfWOrk"></param>
public class MonitoredMachineCommandService(IMonitoredMachineRepository monitoredMachineRepository, IUnitOfWork unitOfWOrk)
    : IMonitoredMachineCommandService
{
    /// <summary>
    /// This method handles the creation of a monitored machine
    /// </summary>
    /// <param name="command"></param>
    /// <returns>
    /// The created monitored machine
    /// </returns>
    /// <exception cref="Exception"></exception>
    /// 
    public async Task<MonitoredMachine> Handle(CreateMonitoredMachineCommand command)
    {
        var machine = await monitoredMachineRepository.FindByNameAndUserIdAsync(command.Name, command.UserId);
        if (machine != null)
            throw new Exception("A product with this name already exists for this user,try with another name");
        
        machine = new MonitoredMachine(command);

        try
        {
            await monitoredMachineRepository.AddAsync(machine);
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            //Change for production
            Console.WriteLine(e);
            return null;
        }

        return machine;
    }
    /// <summary>
    /// this method handles the update of the monitoring status of a monitored machine
    /// </summary>
    /// <param name="command">
    /// <see cref="UpdateMonitoringStatusCommand"/>
    /// </param>
    /// <returns>
    /// The updated monitored machine
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<MonitoredMachine> Handle(UpdateMonitoringStatusCommand command)
    {
        var machine = await monitoredMachineRepository.FindByIdAsync(command.Id);

        if (machine == null)
            throw new ArgumentException("Monitored Machine not found");
        try
        {
            machine.UpdateMonitoringStatus(command);
            monitoredMachineRepository.Update(machine);
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return machine;
    }

    public async Task Handle(DeleteMonitoredMachineCommand command)
    {
        var machine = await monitoredMachineRepository.FindByIdAsync(command.Id);
        if (machine == null)
            throw new ArgumentException("Monitored Machine not found");

        try
        {
            monitoredMachineRepository.Remove(machine);
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}