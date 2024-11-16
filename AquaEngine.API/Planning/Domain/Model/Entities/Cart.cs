using AquaEngine.API.Planning.Domain.Model.Commands;

namespace AquaEngine.API.Planning.Domain.Model.Entities;

public class Cart
{
    public int Id { get; }
    
    public string Name { get; private set; }
    
    public string UrlToImage { get; private set; }
    
    public Cart (string name, string urlToImage)
    {
        Name = name;
        UrlToImage = urlToImage;
    }

    public Cart(CreateCartCommand command)
    {
        Name = command.Name;
        UrlToImage = command.UrlToImage;
    }
}   