namespace NestHubPlatform.Reservations.Domain.Model.Commands;

public record CreateReservationCommand(int LocalId, int TotalAmount, int NumberPerson);