using AquaEngine.API.Sales.Domain.Model.Commands;

namespace AquaEngine.API.Sales.Domain.Model.Aggregates;

public class Invoice
{
    public long Id { get; private set; }  // Genera un ID único
    public string Client { get; private set; }
    public string Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Total { get; private set; }
    public DateTime Date { get; private set; } = DateTime.UtcNow; // Fecha actual por defecto
    
    private Invoice() { }
    public Invoice( string client, string product , int quantity, decimal price, DateTime fecha)
    {
        Client = client;
        Product = product;
        Quantity = quantity;
        Price = price;
        Total = quantity * price;
        Date = fecha;
    }

    public Invoice(CreateInvoiceCommand command)
    {
        Client = command.Client;
        Product = command.Product;
        Quantity = command.Quantity;
        Price = command.Price;
        Total = command.Quantity * command.Price;
        Date = command.Date;
    }
    
}