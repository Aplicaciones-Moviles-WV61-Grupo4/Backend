using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Model.Queries;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Payments.Domain.Services;

namespace NestHubPlatform.Payments.Application.Internal.QueryServices;

public class InvoiceQueryService(IInvoiceRepository invoiceRepository) : IInvoiceQueryService
{
    public async Task<Invoice?> Handle(GetInvoiceByIdQuery query)
    {
        return await invoiceRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query)
    {
        return await invoiceRepository.ListAsync();
    }
}