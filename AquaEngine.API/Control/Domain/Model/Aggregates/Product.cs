using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Domain.Model.ValueObjects;

namespace AquaEngine.API.Control.Domain.Model.Aggregates;

public partial class Product
{

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string QuantityPerUnit { get; private set; }
    public double UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    
    //campo solo para persistir el valor en la base de datos
    public long UserId { get; private set; }

    //valor original de UserId como ValueObject
    public UserId UserIdValue { get; private set; }

    public Product()
    {
    }
    
    public Product(CreateProductCommand command)
    {
        UserIdValue = new UserId(command.UserId);
        
        // Asigna solo el valor int para la persistencia
        UserId = command.UserId; 
        
        Name = command.Name;
        QuantityPerUnit = command.QuantityPerUnit;
        UnitPrice = command.UnitPrice;
        Quantity = command.Quantity;
    }

    public void UpdateProductOwner(UpdateProductOwnerCommand command)
    {
        UserIdValue = new UserId(command.UserId);
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
    
}