using NestHubPlatform.Contacts.Domain.Model.Commands;
using NestHubPlatform.Contacts.Interfaces.REST.Resource;

namespace NestHubPlatform.Contacts.Interfaces.REST.Transform;

public static class CreateContactCommandFromResourceAssembler
{
    public static CreateContactCommand ToCommandFromResources(CreateContactResource resource)
    {
        return new CreateContactCommand(resource.Name, resource.Lastname, resource.Message, resource.Email,
            resource.Phone, resource.propertyId);
    }
}