using AquaEngine.API.Planning.Domain.Model.Entities;
using AquaEngine.API.Planning.Domain.Model.Queries;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Planning.Domain.Services;

namespace AquaEngine.API.Planning.Application.Internal.QueryServices;

public class CartQueryService(ICartRepository cartRepository) : ICartQueryService
{
    public async Task<Cart?> Handle(GetCartByIdQuery query)
    {
        return await cartRepository.FindByIdAsync(query.CartId);
    }

    public async Task<IEnumerable<Cart>> Handle(GetAllCartsQuery query)
    {
        return await cartRepository.ListAsync();
    }
}