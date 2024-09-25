namespace NestHubPlatform.Reservations.Domain.Model.Commands;

public record CreateReservationCommand(int TotalAmount, int NumberPerson);