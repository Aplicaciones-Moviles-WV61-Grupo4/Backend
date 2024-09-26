namespace NestHubPlatform.Reservations.Interfaces.REST.Resources;

public record CreateReservationResource(int LocalId, int TotalAmount, int NumberPerson);