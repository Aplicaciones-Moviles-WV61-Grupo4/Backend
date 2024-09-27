using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Model.ValueObject;

namespace NestHubPlatform.Payments.Domain.Model.Aggregates;

public class Payment
{
    public int Id { get;  }
    public string Reservation { get; set; }
    public float Amount { get; set; }
    public string PaymentMethod { get; set; }
    
    public Invoice Invoices { get; }
    public int InvoiceId { get; private set; }
    public EPaymentStatus Status { get; protected set; }

    public Payment()
    {
        InvoiceId = Invoices.Id;
        Status = EPaymentStatus.Pending;
    }

    public Payment(int invoiceId)
    {
        InvoiceId = invoiceId;
    }

    public void Active()
    {
        Status = EPaymentStatus.Active;
    }

    public void Pending()
    {
        Status = EPaymentStatus.Pending;
    }

    public void Failed()
    {
        Status = EPaymentStatus.Failed;
    }

    public void Expired()
    {
        Status = EPaymentStatus.Expired;
    }

    public void Suspended()
    {
        Status = EPaymentStatus.Suspended;
    }

    public void Canceled()
    {
        Status = EPaymentStatus.Canceled;
    }

    public EPaymentStatus GetStatus()
    {
        return Status;
    }
}