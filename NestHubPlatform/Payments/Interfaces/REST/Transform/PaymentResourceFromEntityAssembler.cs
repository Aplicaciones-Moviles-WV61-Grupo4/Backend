using Microsoft.OpenApi.Extensions;
using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Interfaces.REST.Resources;

namespace NestHubPlatform.Payments.Interfaces.REST.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(entity.Id, entity.Status.GetDisplayName());
    }
}