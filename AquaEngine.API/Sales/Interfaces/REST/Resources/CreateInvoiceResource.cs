namespace AquaEngine.API.Sales.Interfaces.REST.Resources;

public record CreateInvoiceResource( string Client, string Product , int quantity, decimal price, decimal total, DateTime Fecha);