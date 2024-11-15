

using AquaEngine.API.Analytics.Domain.Model.Commands;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;
//Some changes are being made in the monitoring branch
/// <summary>
/// This class represents the maintenance entity
/// </summary>
public partial class Maintenance
{
    /// <summary>
    /// this is the id of the maintenance
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// This is the id of the monitored machine
    /// </summary>
    public int MonitoredMachineId { get; private set; }
    /// <summary>
    /// This is the name of the technician that made the maintenance
    /// </summary>
    public string TechnicianName { get; private set; }
    /// <summary>
    /// This is the description of the maintenance
    /// </summary>
    public string Description { get; private set; }
    /// <summary>
    /// This is the additional info of the maintenance
    /// </summary>
    public string AdditionalInfo { get; private set; }
    /// <summary>
    /// This is the issue type of the maintenance
    /// </summary>
    public string IssueType { get; private set; }
    
    
    
    //Empty Constructor
    Maintenance(){}

    /// <summary>
    /// This constructor creates a maintenance entity from a command
    /// </summary>
    /// <param name="command"></param>
    public Maintenance(CreateMaintenanceCommand command)
    {
        MonitoredMachineId = command.MonitoredMachineId;
        TechnicianName = command.Technician;
        Description = command.Description;
        AdditionalInfo = command.AdditionalInfo;
        IssueType = command.IssueType;
    }
    public Maintenance Update(UpdateMaintenanceCommand command)
    {
        MonitoredMachineId = command.MonitoredMachineId;
        TechnicianName = command.Technician;
        Description = command.Description;
        AdditionalInfo = command.AdditionalInfo;
        IssueType = command.IssueType;
        return this;
    }
}