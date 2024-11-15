using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Domain.Model.ValueObjects;

namespace AquaEngine.API.Planning.Domain.Model.Aggregates;

public class OrderingMachinery
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }
    
    public StockAspect StockAspect { get; private set; }
    
    public OrderingMachinery(string name, string urlToImage, string status, StockAspect stockAspect)
    {
        Name = name;
        UrlToImage = urlToImage;
        Status = status;
        StockAspect = stockAspect;
    }

    public OrderingMachinery(CreateOrderingMachineryCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
        StockAspect = command.StockAspect;
    }
    public void UpdateStatus(UpdateOrderingStatusCommand command)
    {
        Status = command.Status;
    }
}