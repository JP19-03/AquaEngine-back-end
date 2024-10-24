using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;

public partial class MonitoredMachine
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }
    public long UserId{ get; private set; }


    public MonitoredMachine(CreateMonitoredMachineCommand command)
    {
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
        
        
    }

    public void UpdateMonitoringStatus(UpdateMonitoringStatusCommand command)
    {
        
        Status = command.Status;
    }
    
    
}