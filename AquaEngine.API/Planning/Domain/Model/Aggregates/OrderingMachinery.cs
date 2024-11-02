using AquaEngine.API.Planning.Domain.Model.Commands;

namespace AquaEngine.API.Planning.Domain.Model.Aggregates;

public class OrderingMachinery
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }
    
    public OrderingMachinery(string name, string urlToImage, string status)
    {
        Name = name;
        UrlToImage = urlToImage;
        Status = status;
    }

    public OrderingMachinery(CreateOrderingMachineryCommand command)
    {
        Name = command.Name;
        UrlToImage = command.UrlToImage;
        Status = command.Status;
    }
    public void UpdateStatus(UpdateOrderingStatusCommand command)
    {
        Status = command.Status;
    }
}