using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Domain.Model.Queries;

namespace NestHubPlatform.Reservations.Domain.Services;

public interface IReservationQueryService
{
    Task<Reservation?> Handle(GetReservationByIdQuery query);
    Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery query);
}