using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Payments.Infrastructure.EFC.Repositories;

public class InvoiceRepository(AppDbContext context) 
    : BaseRepository<Invoice>(context), IInvoiceRepository
{
    public new async Task<Invoice?> FindByIdAsync(int id) =>
        await Context.Set<Invoice>().Include(t => t.PaymentId)
            .Where(t => t.Id == id).FirstOrDefaultAsync();

    public new async Task<IEnumerable<Invoice>> ListAsync()
    {
        return await Context.Set<Invoice>()
            .Include(i => i.Payments)
            .ToListAsync();
    }
}