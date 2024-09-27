namespace NestHubPlatform.Payments.Domain.Model.Commands;

public record CreateInvoiceCommand(int PaymentId, float Amount);
