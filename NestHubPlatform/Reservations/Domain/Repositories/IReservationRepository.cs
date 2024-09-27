using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Reservations.Domain.Repositories;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    
}