using System.Net.Mime;
using AquaEngine.API.Control.Domain.Model.Queries;
using AquaEngine.API.Control.Domain.Services;
using AquaEngine.API.Control.Interfaces.REST.Resources;
using AquaEngine.API.Control.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Control.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
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
}