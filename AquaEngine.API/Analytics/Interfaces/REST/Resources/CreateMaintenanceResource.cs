namespace AquaEngine.API.Analytics.Interfaces.REST.Resources;

public record CreateMaintenanceResource(int MonitoredMachineId,string Technician, string IssueType, string Description, string AdditionalInfo);
