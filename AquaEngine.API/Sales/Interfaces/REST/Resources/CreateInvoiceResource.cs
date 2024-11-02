namespace AquaEngine.API.Invoice.Interfaces.REST.Resources;

public record CreateInvoiceResource(int Id, string Name, string UrlToImage, string Status);