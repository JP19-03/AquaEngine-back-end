namespace AquaEngine.API.Sales.Domain.Model.Commands;

public record CreateInvoiceCommand(string Client, string Product, int Quantity, decimal Price, decimal Total, DateTime Date);