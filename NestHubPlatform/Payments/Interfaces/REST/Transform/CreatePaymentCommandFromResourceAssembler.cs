using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Interfaces.REST.Resources;

namespace NestHubPlatform.Payments.Interfaces.REST.Transform;

public static class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(resource.Reservation, resource.Amount, resource.PaymentMethod, resource.InvoiceId);
    }
}