namespace NestHubPlatform.Payments.Interfaces.REST.Resources;

public record InvoiceResource(int Id, PaymentResource Payment, float Amount);