namespace NestHubPlatform.Payments.Domain.Model.Commands;

public record CreatePaymentCommand(string Reservation, float Amount, string PaymentMethod, int InvoiceId);