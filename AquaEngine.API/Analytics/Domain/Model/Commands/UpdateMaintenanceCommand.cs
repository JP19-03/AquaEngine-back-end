namespace AquaEngine.API.Analytics.Domain.Model.Commands;

public record UpdateMaintenanceCommand(int Id, int MonitoredMachineId, string Technician, string Description, string AdditionalInfo, string IssueType);