using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Payments.Infrastructure.EFC.Repositories;

public class PaymentRepository(AppDbContext context)
    : BaseRepository<Payment>(context), IPaymentRepository
{
    public new async Task<Payment?> FindByIdAsync(int id) =>
        await Context.Set<Payment>().Include(p => p.Invoices)
            .Where(p => p.Id == id).FirstOrDefaultAsync();

    public new async Task<IEnumerable<Payment>> ListAsync()
    {
        return await Context.Set<Payment>()
            .Include(p => p.Invoices)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> FindByReservationAsync(string reservation)
    {
        return await Context.Set<Payment>()
            .Where(p => p.Reservation == reservation)
            .ToListAsync();

    }
}