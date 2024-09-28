using NestHubPlatform.IAM.Domain.Model.Commands;
using NestHubPlatform.IAM.Interfaces.REST.Resources;

namespace NestHubPlatform.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}