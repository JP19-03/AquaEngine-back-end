

using AquaEngine.API.Analytics.Domain.Model.Commands;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;
//Some changes are being made in the monitoring branch

public partial class Maintenance
{
    
    public int Id { get; private set; }
    public int MonitoredMachineId { get; private set; }
    public string TechnicianName { get; private set; }
    public string Description { get; private set; }
    public string AdditionalInfo { get; private set; }
    public string IssueType { get; private set; }
    
    
    
    //Empty Constructor
    Maintenance(){}

    public Maintenance(CreateMaintenanceCommand command)
    {
        MonitoredMachineId = command.MonitoredMachineId;
        TechnicianName = command.Technician;
        Description = command.Description;
        AdditionalInfo = command.AdditionalInfo;
        IssueType = command.IssueType;
    }
}