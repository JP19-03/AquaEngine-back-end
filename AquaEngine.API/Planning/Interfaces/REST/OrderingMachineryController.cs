using System.Net.Mime;
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
[SwaggerTag("Ordering Machinery Endpoints")]
public class OrderingMachineryController(IOrderingMachineryCommandService orderingMachineryCommandService,
    IOrderingMachineryQueryService orderingMachineryQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Ordering",
        Description = "Create a new Ordering Machinery",
        OperationId = "CreateOrderingMachinery")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Ordering Machinery was created", typeof(OrderingMachineryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Ordering Machinery was not created")]
    public async Task<IActionResult> CreateOrderingMachinery([FromBody] CreateOrderingMachineryResource resource)
    {
        var createOrderingMachineryCommand = CreateOrderingMachineryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await orderingMachineryCommandService.Handle(createOrderingMachineryCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetOrderingMachineryById), new {id = result.Id},
            OrderingMachineryResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Ordering Machinery by Id",
        Description = "Get Ordering Machinery by Id",
        OperationId = "GetOrderingMachineryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Ordering Machinery was found", typeof(OrderingMachineryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Ordering Machinery was not found")]
    public async Task<ActionResult> GetOrderingMachineryById(int id)
    {
        var getOrderingMachineryByIdQuery = new GetOrderingMachineryByIdQuery(id);
        var result = await orderingMachineryQueryService.Handle(getOrderingMachineryByIdQuery);
        if (result is null) return NotFound();
        var resource = OrderingMachineryResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Ordering Machinery",
        Description = "Get all Ordering Machinery",
        OperationId = "GetAllOrderingMachinery")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Ordering Machinery were found", typeof(IEnumerable<OrderingMachineryResource>))]
    public async Task<IActionResult> GetAllOrderingMachinery()
    {
        var getAllOrderingMachineryQuery = new GetAllOrderingMachineryQuery();
        var orderingMachinery = await orderingMachineryQueryService.Handle(getAllOrderingMachineryQuery);
        var resources = orderingMachinery.Select(OrderingMachineryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}