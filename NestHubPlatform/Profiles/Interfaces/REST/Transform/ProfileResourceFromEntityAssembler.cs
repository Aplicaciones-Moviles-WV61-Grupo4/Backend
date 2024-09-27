
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Interfaces.REST.Resources;

namespace NestHubPlatform.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.FullName,
            entity.PhoneNumber,
            entity.NumberDocument,
            entity.BirthDate);
    }
}