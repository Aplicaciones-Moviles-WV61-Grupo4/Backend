using System.Diagnostics;
using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Interfaces.REST.Resources;

namespace NestHubPlatform.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User? user)
    {
        Console.WriteLine("User Name is " + user?.Username);
        Debug.Assert(user != null, nameof(user) + " != null");
        return new UserResource(user.Id, user.Username);
    }
}