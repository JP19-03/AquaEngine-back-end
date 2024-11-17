namespace AquaEngine.API.Sales.Domain.Model.Queries;

public record GetInvoiceByNameAndUserIdQuery(string Name, long UserId);