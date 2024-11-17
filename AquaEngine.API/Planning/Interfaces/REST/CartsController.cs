using System.Net.Mime;
using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Domain.Model.Queries;
using AquaEngine.API.Planning.Domain.Services;
using AquaEngine.API.Planning.Interfaces.REST.Resources;
using AquaEngine.API.Planning.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Planning.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Cart Endpoints")]
public class CartsController(ICartCommandService cartCommandService, ICartQueryService cartQueryService) : ControllerBase
{
    
    [HttpGet("{cartId:int}")]
    [SwaggerOperation(
        Summary = "Get Cart by Id",
        Description = "Get a cart by its unique identifier",
        OperationId = "GetCartById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The cart was found", typeof(CartResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The cart was not found")]
    public async Task<IActionResult> GetCartById(int cartId)
    {
        var getCartByIdQuery = new GetCartByIdQuery(cartId);
        var cart = await cartQueryService.Handle(getCartByIdQuery);
        if (cart is null) return NotFound();
        var cartResource = CartResourceFromEntityAssembler.ToResourceFromEntity(cart);
        return Ok(cartResource);
    }


    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Cart",
        Description = "Create a new cart",
        OperationId = "CreateCart")]
    [SwaggerResponse(StatusCodes.Status201Created, "The cart was created", typeof(CartResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The cart was not created")]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartResource resource)
    {
        var createCartCommand = CreateCartCommandFromResourceAssembler.ToCommandFromResource(resource);
        var cart = await cartCommandService.Handle(createCartCommand);
        if (cart is null) return BadRequest();
        var cartResource = CartResourceFromEntityAssembler.ToResourceFromEntity(cart);
        return CreatedAtAction(nameof(GetCartById), new{cartId = cart.Id}, cartResource);
    }


    [HttpDelete("{cartId:int}")]
    [SwaggerOperation(
        Summary = "Delete Cart",
        Description = "Delete a cart by its unique identifier",
        OperationId = "DeleteCart")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The cart was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The cart was not found")]
    public async Task<IActionResult> DeleteCart(int cartId)
    {
        var resource = new DeleteCartResource(cartId);
        var deleteCartCommand = DeleteCartCommandFromResourceAssembler.ToCommandFromResource(resource);
        await cartCommandService.Handle(deleteCartCommand);
        return NoContent();
    }


    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Carts",
        Description = "Get all carts",
        OperationId = "GetAllCarts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The carts were found", typeof(IEnumerable<CartResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The carts were not found")]
    public async Task<IActionResult> GetAllCats()
    {
        var carts = await cartQueryService.Handle(new GetAllCartsQuery());
        var cartResources = carts.Select(CartResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cartResources);
    }
}