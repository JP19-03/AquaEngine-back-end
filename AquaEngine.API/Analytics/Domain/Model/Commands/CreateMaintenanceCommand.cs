using AquaEngine.API.Analytics.Domain.Model.ValueObjects;

namespace AquaEngine.API.Analytics.Domain.Model.Commands;


//No podemos editar un maintenance log, solo crearlo
//Creamos un monitoredMachineId para poder asociar el mantenimiento a una maquina
/// <summary>
/// This record represents the command to create a maintenance log
/// </summary>
/// <param name="MonitoredMachineId"> </param>
/// <param name="Technician"></param>
/// <param name="IssueType"></param>
/// <param name="Description"></param>
/// <param name="AdditionalInfo"></param>
public record CreateMaintenanceCommand(int MonitoredMachineId,string Technician, string IssueType, string Description, string AdditionalInfo );