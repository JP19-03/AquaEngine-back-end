using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Commands;


//No podemos editar un maintenance log, solo crearlo
//Creamos un monitoredMachineId para poder asociar el mantenimiento a una maquina
public record CreateMaintenanceCommand(int MonitoredMachineId,string Technician, string IssueType, string Description, string AdditionalInfo );