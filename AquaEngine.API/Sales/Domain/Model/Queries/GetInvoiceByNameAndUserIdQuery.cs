namespace AquaEngine.API.Invoice.Domain.Model.Queries;

public record GetInvoiceByNameAndUserIdQuery(string Name, long UserId);