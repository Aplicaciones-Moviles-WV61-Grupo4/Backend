namespace NestHubPlatform.Payments.Interfaces.ACL;

public interface IPaymentContextFacade
{
    Task<int> CreatePayment(int invoiceId);
}