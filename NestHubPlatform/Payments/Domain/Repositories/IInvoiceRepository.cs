using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Payments.Domain.Repositories;

public interface IInvoiceRepository : IBaseRepository<Invoice>
{
    
}