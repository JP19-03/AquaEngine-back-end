using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Domain.Model.ValueObjects;

namespace AquaEngine.API.Control.Domain.Model.Aggregates;

public partial class Product(CreateProductCommand command)
{
    public int Id;
    public UserId UserId = new(command.UserId);
    public string Name = command.Name;
    public double UnitPrice = command.UnitPrice;
    public int Quantity = command.Quantity;

    public void UpdateProductOwner(UpdateProductOwnerCommand command)
    {
        UserId = new UserId(command.UserId);
    }
    
    public void IncreaseQuantity(IncreaseQuantityCommand command)
    {
        Quantity += command.Quantity;
    }   
    
    public void DecreaseQuantity(DecreaseQuantityCommand command)
    {
        if (this.Quantity == 0)
            throw new InvalidOperationException("Product quantity is already 0");
        
        if (this.Quantity < command.Quantity)
            throw new InvalidOperationException("Product quantity is less than the quantity to decrease");

        Quantity -= command.Quantity;
    }

    public long GetUserId()
    {
        return UserId.userId;
    }
    
}