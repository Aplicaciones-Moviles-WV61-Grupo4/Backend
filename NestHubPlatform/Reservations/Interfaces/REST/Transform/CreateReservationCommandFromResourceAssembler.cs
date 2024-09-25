using NestHubPlatform.Reservations.Domain.Model.Commands;
using NestHubPlatform.Reservations.Interfaces.REST.Resources;

namespace NestHubPlatform.Reservations.Interfaces.REST.Transform;

public static class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource)
    {
        return new CreateReservationCommand(resource.TotalAmount, resource.NumberPerson);
    }
}