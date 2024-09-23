using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Domain.Model.Entities;

namespace NestHubPlatform.Payments.Domain.Services;

public interface IInvoiceCommandService
{
    public Task<Invoice?> Handle(CreateInvoiceCommand command);
}