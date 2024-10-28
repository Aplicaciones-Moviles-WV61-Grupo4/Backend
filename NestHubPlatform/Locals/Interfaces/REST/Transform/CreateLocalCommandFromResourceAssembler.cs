using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Interfaces.REST.Resources;

namespace NestHubPlatform.Locals.Interfaces.REST.Transform;

public static class CreateLocalCommandFromResourceAssembler
{
    public static CreateLocalCommand ToCommandFromResources(CreateLocalResource resource)
    {
        return new CreateLocalCommand(resource.District, resource.Street, resource.LocalType, resource.Country, resource.City, resource.Price,
            resource.PhotoUrl, resource.DescriptionMessage, resource.LocalCategoryId, resource.UserId);
    }
}