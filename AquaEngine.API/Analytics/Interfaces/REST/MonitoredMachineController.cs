using System.Net.Mime;
using AquaEngine.API.Analytics.Domain.Model.Commands;
using AquaEngine.API.Analytics.Domain.Model.Queries;
using AquaEngine.API.Analytics.Domain.Services;
using AquaEngine.API.Analytics.Interfaces.REST.Resources;
using AquaEngine.API.Analytics.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Analytics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Monitoring")]
public class MonitoredMachineController(
    IMonitoredMachineCommandService commandService,
    IMonitoredMachineQueryService queryService) : ControllerBase

{
    [HttpPost]
    [SwaggerOperation
    (
        Summary = "Create a new monitored machine",
        Description = "This endpoint is designed to create a new monitoring machine",
        OperationId = "CreateMonitoredMachine")]
    [SwaggerResponse(StatusCodes.Status201Created, "The monitored machine was created",
        typeof(MonitoredMachineResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The monitored machine could not be added")]
    public async Task<IActionResult> CreateMonitoredMachine([FromBody] CreateMonitoredMachineResource resource)
    {
        var command = CreateMonitoredMachineCommandFromResourceAssembler.ToCommandFromResource(resource);
        var machine = await commandService.Handle(command);
        if (machine is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetMonitoredMachineById), new { id = machine.Id },
            MonitoredMachineResourceFromEntityAssembler.ToResourceFromEntity(machine));
    }

    [HttpGet("{id}")]
    [SwaggerOperation
    (
        Summary = "Get a monitored machine by id",
        Description = "This endpoint is designed to get a monitored machine by id",
        OperationId = "GetMonitoredMachineById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The monitored machine was found")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The monitored machine was not found")]

public async Task<IActionResult> GetMonitoredMachineById(int id)
    {
        var getMonitoredMachineById= new GetMonitoredMachineByIdQuery(id);
        var result= await queryService.Handle(getMonitoredMachineById);
        if (result is null)
        {
            return NotFound();
        }
        var resource = MonitoredMachineResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(result);
        
    }

    [SwaggerOperation
    (
        Summary = "Get all monitored machines",
        Description = "This endpoint is designed to get all monitored machines",
        OperationId = "GetAllMonitoredMachines")]
    [SwaggerResponse(StatusCodes.Status200OK, "The monitored machines were found",
        typeof(IEnumerable<MonitoredMachineResource>))]
    [HttpGet]
    public async Task<IActionResult> GetAllMonitoredMachines()
    {
        var getAllMonitoredMachinesQuery = new GetAllMonitoredMachinesQuery();
        var machines = await queryService.Handle(getAllMonitoredMachinesQuery);
        var machineResources = machines.Select(MonitoredMachineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(machineResources);
    }
    
    [SwaggerOperation
    (
   
    Summary = "Delete a monitored machine",
    Description = "This endpoint is designed to delete a monitored machine",
    OperationId = "DeleteMonitoredMachine")]    
    [SwaggerResponse(StatusCodes.Status204NoContent, "The monitored machine was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The monitored machine was not found")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMonitoredMachine(int id)
    {
        var deleteMonitoredMachineCommand = new DeleteMonitoredMachineCommand(id);
        await commandService.Handle(deleteMonitoredMachineCommand);
        return NoContent();
    }
}