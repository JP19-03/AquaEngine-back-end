using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;

public partial class MonitoredMachine
{
    /// <summary>
    /// The unique identifier of the monitored machine.
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// The name of the monitored machine.
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// The url to the image of the monitored machine.
    /// </summary>
    public string UrlToImage { get; private set; }
    public EMachineStatus Status { get; private set; }

    public long UserId{ get; private set; }

    public MonitoredMachine() { }

    /// <summary>
    /// This constructor creates a monitored machine entity from a command
    /// </summary>
    /// <param name="command"> <see cref="CreateMonitoredMachineCommand"/> </param>
    public MonitoredMachine(CreateMonitoredMachineCommand command)
    {
        UserId = command.UserId;
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
    }
    /// <summary>
    /// This method updates the monitoring status of the monitored machine
    /// </summary>
    /// <param name="command"> <see cref="UpdateMonitoringStatusCommand"/> </param>
    public void UpdateMonitoringStatus(UpdateMonitoringStatusCommand command)
    {
        Status = command.Status;
    }
    
    
}