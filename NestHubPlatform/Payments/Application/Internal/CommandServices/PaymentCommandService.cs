using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Domain.Repositories;
using NestHubPlatform.Payments.Domain.Services;

namespace NestHubPlatform.Payments.Application.Internal.CommandServices
{
    public class PaymentCommandService(IPaymentRepository paymentRepository,
        IInvoiceRepository invoiceRepository,
        IUnitOfWork unitOfWork) : IPaymentCommandService
    {
        
        public async Task<Payment?> Handle(CreatePaymentCommand command)
        {
            var payment = new Payment(command.Reservation, command.Amount, command.PaymentMethod, command.InvoiceId);
            await paymentRepository.AddAsync(payment);
            await unitOfWork.CompleteAsync();

            var invoice = await invoiceRepository.FindByIdAsync(command.InvoiceId);
            payment.Invoice = invoice;
            return payment;
        }

    }
}
