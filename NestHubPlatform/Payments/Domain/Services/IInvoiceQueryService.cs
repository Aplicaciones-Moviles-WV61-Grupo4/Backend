using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Model.Queries;

namespace NestHubPlatform.Payments.Domain.Services;

public interface IInvoiceQueryService
{
    Task<Invoice?> Handle(GetInvoiceByIdQuery query);
    Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query);
}