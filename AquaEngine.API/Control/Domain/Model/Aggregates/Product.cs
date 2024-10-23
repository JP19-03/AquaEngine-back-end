using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Domain.Model.ValueObjects;

namespace AquaEngine.API.Control.Domain.Model.Aggregates;

public partial class Product
{

    public int Id { get; private set; }
    public long UserId { get; private set; }
    public string Name { get; private set; }
    public string QuantityPerUnit { get; private set; }
    public double UnitPrice { get; private set; }
    public int Quantity { get; private set; }

    public Product()
    {
    }
    
    public Product(CreateProductCommand command)
    {
        UserId = command.UserId;
        Name = command.Name;
        QuantityPerUnit = command.QuantityPerUnit;
        UnitPrice = command.UnitPrice;
        Quantity = command.Quantity;
    }

    public void UpdateProductOwner(UpdateProductOwnerCommand command)
    {
        UserId = command.UserId;
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
        return UserId;
    }
    
}