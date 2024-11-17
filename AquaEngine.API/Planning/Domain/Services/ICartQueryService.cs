using AquaEngine.API.Planning.Domain.Model.Entities;
using AquaEngine.API.Planning.Domain.Model.Queries;

namespace AquaEngine.API.Planning.Domain.Services;

public interface ICartQueryService
{
    /// <summary>
    /// Handles the get cart by id query in the AquaEngine Planning domain
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetCartByIdQuery"/> query to handle.
    /// </param>
    /// <returns></returns>
    Task<Cart?> Handle(GetCartByIdQuery query);
    
    /// <summary>
    /// Handles the get all carts query in the AquaEngine Planning domain 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllCartsQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all carts in the AquaEngine Planning domain
    /// </returns>
    Task<IEnumerable<Cart>> Handle(GetAllCartsQuery query);
}