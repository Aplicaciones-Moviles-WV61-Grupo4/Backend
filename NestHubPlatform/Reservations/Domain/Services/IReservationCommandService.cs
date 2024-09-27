using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Domain.Model.Commands;

namespace NestHubPlatform.Reservations.Domain.Services;

public interface IReservationCommandService
{
    public Task<Reservation?> Handle(CreateReservationCommand command);
}