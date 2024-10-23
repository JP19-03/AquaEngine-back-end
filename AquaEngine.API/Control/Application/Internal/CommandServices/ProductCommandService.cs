using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Domain.Repositories;
using AquaEngine.API.Control.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Control.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWOrk unitOfWOrk)
    : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = await productRepository.FindByNameAsync(command.Name);

        if (product != null)
            throw new Exception("Product with this name already exists");

        product = new Product(command);

        try
        {
            await productRepository.AddAsync(product);
            await unitOfWOrk.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return product;
    }

    public async Task<Product?> Handle(DecreaseQuantityCommand command)
    {
        return await HandleQuantityCommand(command.ProductId, 
            command.Quantity, product => product.DecreaseQuantity(command));
    }

    public async Task<Product?> Handle(IncreaseQuantityCommand command)
    {
        return await HandleQuantityCommand(command.ProductId, 
            command.Quantity, product => product.IncreaseQuantity(command));
    }

    public Task<Product?> Handle(UpdateProductOwnerCommand command)
    {
        throw new NotImplementedException();
    }
    
    private async Task<Product?> HandleQuantityCommand(int productId, int quantity, Action<Product> modifyQuantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        var product = await productRepository.FindByIdAsync(productId);

        if (product == null)
            throw new ArgumentException("Product not found");

        modifyQuantity(product);

        try
        {
            productRepository.Update(product);
            await unitOfWOrk.CompleteAsync();
            return product;
        }
        catch (Exception)
        {
            return null;
        }
    }
}