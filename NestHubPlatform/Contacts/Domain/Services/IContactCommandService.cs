using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Domain.Model.Commands;

namespace NestHubPlatform.Contacts.Domain.Services;

public interface IContactCommandService
{
    Task<Contact?> Handle(CreateContactCommand command);
}