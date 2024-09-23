using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Interfaces.REST.Resources;

namespace NestHubPlatform.Payments.Interfaces.REST.Transform;

public static class InvoiceResourceFromEntityAssembler
{
    public static InvoiceResource ToResourceFromEntity(Invoice entity)
    {
        return new InvoiceResource(entity.Id,
            PaymentResourceFromEntityAssembler.ToResourceFromEntity(entity.Payment),
            entity.Amount);
    }
}