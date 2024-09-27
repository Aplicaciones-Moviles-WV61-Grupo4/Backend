using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Contacts.Domain.Repositories;

public interface IContactRepository : IBaseRepository<Contact>
{
    Task<Contact?> FindBypropertyIdAsync(int queryPropertyId);
        Task<Contact?> FindByIdAsync(int id);

}