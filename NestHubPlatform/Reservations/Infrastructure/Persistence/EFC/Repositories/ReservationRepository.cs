using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Reservations.Infrastructure.Persistence.EFC.Repositories;

public class ReservationRepository(AppDbContext context)
    : BaseRepository<Reservation>(context), IReservationRepository
{
}