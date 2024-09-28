using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Payments.Infrastructure.EFC.Repositories;

public class PaymentRepository(AppDbContext context)
    : BaseRepository<Payment>(context), IPaymentRepository
{
}