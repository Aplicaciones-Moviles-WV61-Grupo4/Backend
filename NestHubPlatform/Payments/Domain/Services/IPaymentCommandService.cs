using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Model.Commands;

namespace NestHubPlatform.Payments.Domain.Services;

public interface IPaymentCommandService
{
    public Task<Payment?> Handle(CreatePaymentCommand command);
}