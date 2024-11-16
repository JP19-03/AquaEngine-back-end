namespace AquaEngine.API.Planning.Domain.Model.Queries;

/// <summary>
/// Get cart by id query
/// </summary>
/// <param name="CartId">
/// Id of the cart to get
/// </param>
public record GetCartByIdQuery(int CartId);