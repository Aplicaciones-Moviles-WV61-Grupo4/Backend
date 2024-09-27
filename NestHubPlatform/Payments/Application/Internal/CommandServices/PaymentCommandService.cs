using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Domain.Repositories;
using System.Threading.Tasks;
using NestHubPlatform.Payments.Domain.Model.ValueObject;
using NestHubPlatform.Payments.Domain.Services;

namespace NestHubPlatform.Payments.Application.Internal.CommandServices
{
    public class PaymentCommandService : IPaymentCommandService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentCommandService(
            IPaymentRepository paymentRepository,
            IInvoiceRepository invoiceRepository,
            IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Payment?> Handle(CreatePaymentCommand command)
        {
            var invoice = await _invoiceRepository.FindByIdAsync(command.InvioceId);
            if (invoice == null)
            {
                throw new KeyNotFoundException("Invoice not found for the provided InvoiceId.");
            }

            var payment = new Payment(command.InvioceId);
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();

            return payment;
        }

    }
}
