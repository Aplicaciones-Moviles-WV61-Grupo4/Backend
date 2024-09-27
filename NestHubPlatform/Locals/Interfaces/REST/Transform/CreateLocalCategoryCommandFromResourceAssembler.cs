using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Interfaces.REST.Resources;

namespace NestHubPlatform.Locals.Interfaces.REST.Transform;

public class CreateLocalCategoryCommandFromResourceAssembler
{
    public static CreateLocalCategoryCommand ToCommandFromResource(CreateLocalCategoryResource resource)
    {
        return new CreateLocalCategoryCommand(resource.Name);
    }
}