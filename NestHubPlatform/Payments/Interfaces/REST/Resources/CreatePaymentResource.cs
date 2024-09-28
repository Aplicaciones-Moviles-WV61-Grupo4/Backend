namespace NestHubPlatform.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(string Reservation, float Amount, string PaymentMethod, int InvoiceId);