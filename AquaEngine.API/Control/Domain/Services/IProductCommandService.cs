using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Commands;

namespace AquaEngine.API.Control.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
    Task<Product?> Handle(DecreaseQuantityCommand command);
    Task<Product?> Handle(IncreaseQuantityCommand command);
    Task<Product?> Handle(UpdateProductOwnerCommand command);
   Task Handle(DeleteProductCommand command);
}