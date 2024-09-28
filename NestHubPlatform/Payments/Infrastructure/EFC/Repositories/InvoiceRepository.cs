using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Payments.Infrastructure.EFC.Repositories;

public class InvoiceRepository(AppDbContext context) 
    : BaseRepository<Invoice>(context), IInvoiceRepository
{
}