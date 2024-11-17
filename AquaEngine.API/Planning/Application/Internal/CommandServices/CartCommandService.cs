using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Domain.Model.Entities;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Planning.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Planning.Application.Internal.CommandServices;

public class CartCommandService(
    ICartRepository cartRepository,
    IUnitOfWork unitOfWork) : ICartCommandService
{
    public async Task<Cart?> Handle(CreateCartCommand command)
    {
        var cart = new Cart(command);
        await cartRepository.AddAsync(cart);
        await unitOfWork.CompleteAsync();
        return cart;
    }

    public async Task Handle(DeleteCartCommand command)
    {
        var cart = await cartRepository.FindByIdAsync(command.Id);
        if(cart == null)
        {
            throw new ArgumentException("Cart not found");
        }

        try
        {
            cartRepository.Remove(cart);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error deleting cart", e);
        }
    }
}