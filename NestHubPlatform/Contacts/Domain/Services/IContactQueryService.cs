using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Domain.Model.Queries;

namespace NestHubPlatform.Contacts.Domain.Services;

public interface IContactQueryService
{
    Task<IEnumerable<Contact>> Handle(GetAllContactQuery query);
    Task<Contact?> Handle(GetContactsBypropertyIdQuery query);
    Task<Contact?> Handle(GetContactByIdQuery query);

}