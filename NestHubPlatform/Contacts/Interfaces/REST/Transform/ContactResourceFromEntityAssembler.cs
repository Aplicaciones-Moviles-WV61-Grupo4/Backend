using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Interfaces.REST.Resource;

namespace NestHubPlatform.Contacts.Interfaces.REST.Transform;

public static class ContactResourceFromEntityAssembler
{
    public static ContactResource ToResourceFromEntity(Contact contact)
    {
        return new ContactResource(
            contact.Id,
            contact.Email,
            contact.Message,
            contact.NameSurname,
            contact.Phone,
            contact.propertyId,
            contact.UserId);
    }
}