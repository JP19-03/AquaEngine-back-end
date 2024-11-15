using System.Net.Mime;
using AquaEngine.API.Control.Domain.Model.Commands;
using AquaEngine.API.Control.Domain.Model.Queries;
using AquaEngine.API.Control.Domain.Services;
using AquaEngine.API.Control.Interfaces.REST.Resources;
using AquaEngine.API.Control.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Control.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Products")]
public class ProductsController(IProductCommandService productCommandService, 
    IProductQueryService productQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new product",
        Description = "Create a new product",
        OperationId = "CreateProduct")]
    [SwaggerResponse(StatusCodes.Status201Created, "The product was created", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The product could not be created")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var result = await productCommandService.Handle(createProductCommand);
        
        if (result is null)
            return BadRequest();
        
        return CreatedAtAction(nameof(GetProductById), new { id = result.Id },
           ProductResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a product by ID",
        Description = "Get a product source by the specified ID",
        OperationId = "GetProductById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was found", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var getProductByIdQuery = new GetProductByIdQuery(id);
        
        var result = await productQueryService.Handle(getProductByIdQuery);
        
        if (result is null)
            return NotFound();

        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(result);
    }
    
    [SwaggerOperation
    (
        Summary = "Get all products",
        Description = "This endpoint is designed to get all products",
        OperationId = "GetAllProducts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The products were found",
        typeof(IEnumerable<ProductResource>))]
    [HttpGet]
    public async Task<IActionResult> GetAllMonitoredMachines()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var machines = await productQueryService.Handle(getAllProductsQuery);
        var productResources = machines.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(productResources);
    }

    
    [HttpPut("owner")]
    [SwaggerOperation(
        Summary = "Update the owner of a product",
        Description = "Update the owner of the specified product",
        OperationId = "UpdateProductOwner")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product owner was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data provided")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<ActionResult> UpdateProductOwner([FromBody] UpdateProductOwnerResource resource)
    {
        if (resource.UserId <= 0 || resource.ProductId <= 0) 
            return BadRequest("Invalid resource data");

        var updateOwnerCommand = new UpdateProductOwnerCommand(resource.UserId, resource.ProductId);

        var result = await productCommandService.Handle(updateOwnerCommand);

        if (result is null)
            return NotFound("The product or user was not found");

        return Ok("Product owner updated successfully");
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a product by ID",
        Description = "Delete the product with the specified ID",
        OperationId = "DeleteProduct")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The product was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var resource = new DeleteProductResource(id);
        
        var deleteProductCommand = DeleteProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        await productCommandService.Handle(deleteProductCommand);
        
        return NoContent();
    }
}