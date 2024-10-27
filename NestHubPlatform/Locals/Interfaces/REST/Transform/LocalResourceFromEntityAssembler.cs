using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Interfaces.REST.Resources;

namespace NestHubPlatform.Locals.Interfaces.REST.Transform;

public static class LocalResourceFromEntityAssembler
{
    public static LocalResource ToResourceFromEntity(Local local)
    {
        return new LocalResource(
            local.Id,
            local.Title,  // Añadido `Title` en lugar de `LocalType`
            local.StreetAddress,
            local.CityPlace,
            local.NightPrice,
            local.PhotoUrl,
            local.DescriptionMessage,
            LocalCategoryResourceFromEntityAssembler.ToResourceFromEntity(local.LocalCategory),
            local.UserId);
    }
}