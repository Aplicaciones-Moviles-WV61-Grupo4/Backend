namespace NestHubPlatform.Payments.Interfaces.REST.Resources;

public record CreateInvoiceResource(int PaymentIdi, float Amount);