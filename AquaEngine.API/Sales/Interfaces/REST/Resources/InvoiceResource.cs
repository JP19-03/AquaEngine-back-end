namespace AquaEngine.API.Sales.Interfaces.REST.Resources;

public record InvoiceResource(long Id, string Client, string Product, int Quantity, decimal Price, decimal Total, DateTime Date); 