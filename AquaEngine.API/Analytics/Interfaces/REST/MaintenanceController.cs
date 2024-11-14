using System.Net.Mime;
using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Analytics.Domain.Model.Queries;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;
using AquaEngine.API.Analytics.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Analytics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]s")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Maintenances")]
public class MaintenanceController(
    IMaintenanceCommandService commandService,
    IMaintenanceQueryService queryService) :ControllerBase
{
    [HttpPost]
    [SwaggerOperation
    (Summary = "Create a new maintenance log",
        Description = "This endpoint is designed to create a new maintenance log",
        OperationId = "CreateMaintenanceLog")]
    [SwaggerResponse(StatusCodes.Status201Created, "The maintenance log was created",
        typeof(MaintenanceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The maintenance log could not be added")]
    public async Task<IActionResult> CreateMaintenanceLog([FromBody] CreateMaintenanceResource resource)
    {
        var command = CreateMaintenanceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var maintenance = await commandService.Handle(command);
        if (maintenance is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetMaintenanceById), new { id = maintenance.Id },
            MaintenanceResourceFromEntityAssembler.ToResourceFromEntity(maintenance));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a maintenance log by id",
        Description = "This endpoint is designed to get a maintenance log by id",
        OperationId = "GetMaintenanceById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The maintenance log was found")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The maintenance log was not found")]
    public async Task<IActionResult> GetMaintenanceById(int id)
    {
        var getMaintenanceById = new GetMaintenanceByIdQuery(id);
        var result = await queryService.Handle(getMaintenanceById);
        if (result is null)
        {
            return NotFound();
        }
        var resource = MaintenanceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(result);
    }

    [SwaggerOperation(
        Summary = "Get all maintenance logs",
        Description = "This endpoint is designed to get all maintenance logs",
        OperationId = "GetAllMaintenanceLogs")]
    [SwaggerResponse(StatusCodes.Status200OK, "The maintenance logs were found", typeof(IEnumerable<Maintenance>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The maintenance logs were not found")]
    [HttpGet]
    public async Task<IActionResult> GetAllMaintenance()
    {
        var getAllMaintenance = new GetAllMaintenance();
        var maintenance = await queryService.Handle(getAllMaintenance);
        var maintenanceResources = maintenance.Select(MaintenanceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(maintenanceResources);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a maintenance log",
        Description = "This endpoint is designed to update a maintenance log",
        OperationId = "UpdateMaintenanceLog")]
    [SwaggerResponse(StatusCodes.Status200OK, "The maintenance log was updated",
        typeof(MaintenanceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The maintenance log could not be updated")]
    public async Task<IActionResult> UpdateMaintenanceLog(int id, [FromBody] UpdateMaintenanceResource resource)
    {
        var command = UpdateMaintenanceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var maintenance = await commandService.Handle(command);
        if (maintenance is null)
        {
            return BadRequest();
        }

        return Ok(MaintenanceResourceFromEntityAssembler.ToResourceFromEntity(maintenance));
    }
}