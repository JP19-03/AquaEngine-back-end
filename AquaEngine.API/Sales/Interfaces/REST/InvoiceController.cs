using System.Net.Mime;
using AquaEngine.API.Sales.Interfaces.REST.Transform;
using AquaEngine.API.Sales.Domain.Model.Queries;
using AquaEngine.API.Sales.Domain.Services;
using AquaEngine.API.Sales.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Sales.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Invoice Endpoints")]
public class InvoiceController(IInvoiceCommandService invoiceCommandService,
    IInvoiceQueryService invoiceQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Invoice",
        Description = "Create a new Invoice",
        OperationId = "CreateInvoice")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Invoice was created", typeof(InvoiceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Invoice was not created")]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceResource resource)
    {
        var createInvoiceCommand = CreateInvoiceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await invoiceCommandService.Handle(createInvoiceCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetInvoiceById), new {id = result.Id},
            InvoiceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Invoice by Id",
        Description = "Get Invoice by Id",
        OperationId = "GetInvoiceById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Invoice was found", typeof(InvoiceResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Invoice was not found")]
    public async Task<ActionResult> GetInvoiceById(int id)
    {
        var getInvoiceByIdQuery = new GetInvoiceByIdQuery(id);
        var result = await invoiceQueryService.Handle(getInvoiceByIdQuery);
        if (result is null) return NotFound();
        var resource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Invoice",
        Description = "Get all Invoice",
        OperationId = "GetAllInvoice")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Invoice were found", typeof(IEnumerable<InvoiceResource>))]
    public async Task<IActionResult> GetAllInvoice()
    {
        var getAllInvoiceQuery = new GetAllInvoiceQuery();
        var invoice = await invoiceQueryService.Handle(getAllInvoiceQuery);
        var resources = invoice.Select(InvoiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}