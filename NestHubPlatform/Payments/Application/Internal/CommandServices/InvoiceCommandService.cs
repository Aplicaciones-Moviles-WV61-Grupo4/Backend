using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Domain.Repositories;
using System.Threading.Tasks;
using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Services;

namespace NestHubPlatform.Payments.Application.Internal.CommandServices;

public class InvoiceCommandService : IInvoiceCommandService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceCommandService(
        IInvoiceRepository invoiceRepository,
        IPaymentRepository paymentRepository,
        IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Invoice?> Handle(CreateInvoiceCommand command)
    {
        var payment = await _paymentRepository.FindByIdAsync(command.PaymentId);
        
        if (payment == null)
        {
            throw new KeyNotFoundException("Payment not found for the provided PaymentId.");
        }

        var invoice = new Invoice(command.PaymentId, command.Amount);
        invoice.AddPayment(payment);
        
        
        
        await _invoiceRepository.AddAsync(invoice);
        
        await _unitOfWork.CompleteAsync();

        return invoice;
    }
}