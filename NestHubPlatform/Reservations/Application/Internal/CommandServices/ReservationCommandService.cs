using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Domain.Model.Commands;
using NestHubPlatform.Reservations.Domain.Repositories;
using NestHubPlatform.Reservations.Domain.Services;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Reservations.Application.Internal.CommandServices;

public class ReservationCommandService(
    IReservationRepository reservationRepository,
    IUnitOfWork unitOfWork): IReservationCommandService
{
    public async Task<Reservation?> Handle(CreateReservationCommand command)
    {
        var reservation = new Reservation(command.LocalId, command.TotalAmount, command.NumberPerson);
        await reservationRepository.AddAsync(reservation);
        await unitOfWork.CompleteAsync();

        return reservation;
    }
}