namespace AquaEngine.API.Analytics.Interfaces.REST.Resources;

public record UpdateMaintenanceResource(int Id, int MonitoredMachineId,string TechnicianName,string Description, string AdditionalInfo, string IssueType);