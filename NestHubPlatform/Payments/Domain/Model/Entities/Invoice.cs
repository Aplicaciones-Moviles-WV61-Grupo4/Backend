using NestHubPlatform.Payments.Domain.Model.Aggregates;

namespace NestHubPlatform.Payments.Domain.Model.Entities;

public class Invoice
{
    public int Id { get; private set; }
    public float Amount { get; private set; }
    public DateTime Date { get; private set; }
    public Payment Payment { get; internal set; }
    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
    public int PaymentId { get; private set; }

    public Invoice(int paymentId, float amount)
    {
        PaymentId = paymentId;
        Amount = amount;
        Date = DateTime.Now;
    }

    public void AddPayment(Payment payment)
    {
        Payments.Add(payment);
    }
}