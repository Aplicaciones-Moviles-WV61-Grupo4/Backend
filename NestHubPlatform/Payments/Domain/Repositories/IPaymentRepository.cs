using NestHubPlatform.Shared.Domain.Repositories;
using NestHubPlatform.Payments.Domain.Model.Aggregates;

namespace NestHubPlatform.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    
}