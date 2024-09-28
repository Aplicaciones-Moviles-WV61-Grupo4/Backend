using NestHubPlatform.Payments.Domain.Model.Commands;
using NestHubPlatform.Payments.Domain.Services;

namespace NestHubPlatform.Payments.Interfaces.ACL.Services;

public class PaymentContextFacade(IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService) : IPaymentContextFacade
{
    /*public async Task<int> CreatePayment(int invoiceId)
    {
        var createPaymentCommand = new CreatePaymentCommand(invoiceId);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        return payment?.Id ?? 0;
    }*/
}