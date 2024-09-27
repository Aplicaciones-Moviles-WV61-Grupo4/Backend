using Microsoft.AspNetCore.Mvc;
using NestHubPlatform.Payments.Domain.Model.Queries;
using NestHubPlatform.Payments.Domain.Services;
using NestHubPlatform.Payments.Interfaces.REST.Resources;
using NestHubPlatform.Payments.Interfaces.REST.Transform;

namespace NestHubPlatform.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentController(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePayment(
        [FromBody] CreatePaymentResource createPaymentResource)
    {
        var createPaymentCommand =
            CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(createPaymentResource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);

        return CreatedAtAction(nameof(GetPaymentById), new { paymentId = resource.Id }, resource);
    }

    [HttpGet("{paymentId}")]
    public async Task<IActionResult> GetPaymentById(
        [FromBody] int paymentId)
    {
        var payment = await paymentQueryService.Handle(new GetPaymentByIdQuery(paymentId));
        if (payment == null) return NotFound();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await paymentQueryService.Handle(new GetAllPaymentsQuery());
        var resource = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    
}