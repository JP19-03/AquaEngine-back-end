namespace AquaEngine.API.Invoice.Domain.Model.Commands;

public record CreateInvoiceCommand(int Id, string Name, string UrlToImage, string Status);