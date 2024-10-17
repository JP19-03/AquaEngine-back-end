namespace AquaEngine.API.Analytics.Domain.Model.Aggregates;

/// MonitoredMachinery Aggregate
/// <summary>
/// This class represents the MonitoredMachinery aggregate. It is used to store the monitored machinery of a user.
/// </summary>
public class MonitoredMachinery
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string UrlToImage { get; private set; }
    public string Status { get; private set; }

    protected MonitoredMachinery()
    {
        this.Name = string.Empty;
        this.UrlToImage = string.Empty;
        this.Status = string.Empty;
    }
}