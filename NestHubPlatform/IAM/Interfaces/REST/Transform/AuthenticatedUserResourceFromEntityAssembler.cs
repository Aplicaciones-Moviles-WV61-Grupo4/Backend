using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Interfaces.REST.Resources;

namespace NestHubPlatform.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}