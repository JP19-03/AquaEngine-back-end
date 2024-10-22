using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Commands;

namespace AquaEngine.API.Control.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> handle(CreateProductCommand command);
    Task<Product?> handle(DecreaseQuantityCommand command);
    Task<Product?> handle(IncreaseQuantityCommand command);
    Task<Product?> handle(UpdateProductOwnerCommand command);
}