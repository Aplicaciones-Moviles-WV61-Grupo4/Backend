namespace NestHubPlatform.Payments.Domain.Model.ValueObject;

public enum EPaymentStatus
{
    Active,
    Pending,
    Failed,
    Expired,
    Suspended,
    Canceled
}