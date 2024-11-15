using AquaEngine.API.Sales.Domain.Model.Commands;

namespace AquaEngine.API.Sales.Domain.Model.Aggregates;

public class Invoice
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }
    
    public Invoice( string name, string urlToImage, string status)
    {
        
        Name = name;
        UrlToImage = urlToImage;
        Status = status;
    }

    public Invoice(CreateInvoiceCommand command)
    {
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
    }
    public void UpdateStatus(UpdateInvoiceStatusCommand command)
    {
        Status = command.Status;
    }
}