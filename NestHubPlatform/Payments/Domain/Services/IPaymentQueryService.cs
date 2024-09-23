using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Model.Queries;

namespace NestHubPlatform.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<Payment?> Handle(GetPaymentByIdQuery query);
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
}