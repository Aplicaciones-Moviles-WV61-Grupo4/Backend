using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Domain.Model.Queries;
using NestHubPlatform.Reservations.Domain.Repositories;
using NestHubPlatform.Reservations.Domain.Services;

namespace NestHubPlatform.Reservations.Application.Internal.QueryServices;

public class ReservationQueryService(IReservationRepository reservationRepository) : IReservationQueryService
{
    public async Task<Reservation?> Handle(GetReservationByIdQuery query)
    {
        return await reservationRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery query)
    {
        return await reservationRepository.ListAsync();
    }
}