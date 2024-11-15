using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Domain.Model.ValueObjects;

namespace AquaEngine.API.Planning.Domain.Model.Aggregates;

public class OrderingMachinery
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }
    
    public EStockAspect EStockAspect { get; private set; }
    
    public OrderingMachinery(string name, string urlToImage, string status, EStockAspect eStockAspect)
    {
        Name = name;
        UrlToImage = urlToImage;
        Status = status;
        EStockAspect = eStockAspect;
    }

    public OrderingMachinery(CreateOrderingMachineryCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
        EStockAspect = command.EStockAspect;
    }
    public void UpdateStatus(UpdateOrderingStatusCommand command)
    {
        Status = command.Status;
    }
}