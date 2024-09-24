using Microsoft.AspNetCore.Mvc;
using NestHubPlatform.Payments.Domain.Model.Queries;
using NestHubPlatform.Payments.Domain.Services;
using NestHubPlatform.Payments.Interfaces.REST.Resources;
using NestHubPlatform.Payments.Interfaces.REST.Transform;

namespace NestHubPlatform.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InvoiceController(
    IInvoiceCommandService invoiceCommandService,
    IInvoiceQueryService invoiceQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInvoice(
        [FromBody] CreateInvoiceResource createInvoiceResource)
    {
        var createInvoiceCommand =
            CreateInvoiceCommandFromResourceAssembler.ToCommandFromResource(createInvoiceResource);
        var invoice = await invoiceCommandService.Handle(createInvoiceCommand);
        if (invoice is null) return BadRequest();

        var resource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return CreatedAtAction(nameof(GetInvoiceById), new { invoiceId = resource.Id }, resource);
    }

    [HttpGet("{invoiceId}")]
    public async Task<IActionResult> GetInvoiceById(
        int invoiceId)
    {
        var invoice = await invoiceQueryService.Handle(new GetInvoiceByIdQuery(invoiceId));
        if (invoice == null) return NotFound();

        var resource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var invoices = await invoiceQueryService.Handle(new GetAllInvoicesQuery());
        var resources = invoices.Select(InvoiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}