using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Domain.Repositories;
using System.Threading.Tasks;
using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Services;

namespace NestHubPlatform.Payments.Application.Internal.CommandServices;

public class InvoiceCommandService(IInvoiceRepository invoiceRepository,
    IUnitOfWork unitOfWork) : IInvoiceCommandService
{
    public async Task<Invoice?> Handle(CreateInvoiceCommand command)
    {
        var invoice = new Invoice(command.PaymentId, command.Amount);
        await invoiceRepository.AddAsync(invoice);
        await unitOfWork.CompleteAsync();
        return invoice;
    }
}