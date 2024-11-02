namespace AquaEngine.API.Planning.Domain.Model.Commands;
/// <summary>
/// This command is used to update the status of a ordering machinery
/// </summary>
/// <param name="Id">The ID of the order machinery</param>
/// <param name="Status">The status of the ordering machinery</param>
public record UpdateOrderingStatusCommand(int Id, string Status);