using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Domain.Model.Queries;
using NestHubPlatform.Contacts.Domain.Repositories;
using NestHubPlatform.Contacts.Domain.Services;

namespace NestHubPlatform.Contacts.Application.Internal.QueryService;

public class ContactQueryService(IContactRepository contactRepository) : IContactQueryService
{
    public async Task<IEnumerable<Contact>> Handle(GetAllContactQuery query)
    {
        return await contactRepository.ListAsync();
    }

    public async Task<Contact?> Handle(GetContactsBypropertyIdQuery query)
    {
        return await contactRepository.FindBypropertyIdAsync(query.propertyId);
    }

    public Task<Contact?> Handle(GetContactByIdQuery query)
    {
        return contactRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Contact>> FindBypropertysIdAsync(int queryPropertyId)
    {
        return await contactRepository.FindBypropertyIdAsync(queryPropertyId);
    }
}