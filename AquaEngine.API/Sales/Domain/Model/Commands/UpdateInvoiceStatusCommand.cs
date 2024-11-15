namespace AquaEngine.API.Sales.Domain.Model.Commands;
/// <summary>
/// This command is used to update the status of a Invoice
/// </summary>
/// <param name="Id">The ID of the Invoice</param>
/// <param name="Status">The status of the Invoice</param>
public record UpdateInvoiceStatusCommand(int Id, string Status);