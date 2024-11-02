using AquaEngine.API.Invoice.Domain.Model.ValueObjects;

namespace AquaEngine.API.Invoice.Domain.Model.Queries;

public record GetInvoiceByUserIdQuery(UserId UserId);