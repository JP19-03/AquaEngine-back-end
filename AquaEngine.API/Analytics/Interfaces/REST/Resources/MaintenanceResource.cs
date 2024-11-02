namespace AquaEngine.API.Analytics.Interfaces.REST.Resources;

public record MaintenanceResource(int Id,int MonitoredMachineId,string  TechnicianName, string Description, string AdditionalInfo, string IssueType);