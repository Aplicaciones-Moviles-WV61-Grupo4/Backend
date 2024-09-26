using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Interfaces.REST.Resources;

namespace NestHubPlatform.Reservations.Interfaces.REST.Transform;

public static class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(Reservation entity)
    {
        return new ReservationResource(entity.Id, entity.LocalId, entity.TotalAmount, entity.NumberPerson);
    }
    
}