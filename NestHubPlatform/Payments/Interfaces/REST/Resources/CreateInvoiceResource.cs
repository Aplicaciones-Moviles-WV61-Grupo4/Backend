namespace NestHubPlatform.Payments.Interfaces.REST.Resources;

public record CreateInvoiceResource(int PaymentId, float Amount);