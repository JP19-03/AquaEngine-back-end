namespace AquaEngine.API.Sales.Domain.Model.Commands;

public record CreateInvoiceCommand(int Id, string Name, string UrlToImage, string Status);