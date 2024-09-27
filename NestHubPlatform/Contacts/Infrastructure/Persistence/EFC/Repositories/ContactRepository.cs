using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NestHubPlatform.Contacts.Infrastructure.Persistence.EFC.Repositories;

public class ContactRepository(AppDbContext context) : BaseRepository<Contact>(context), IContactRepository
{
    private IContactRepository _contactRepositoryImplementation;

    public Task<Contact?> FindBypropertyIdAsync(int queryPropertyId)
    {
        return context.Set<Contact>().FirstOrDefaultAsync(c => c.propertyId == queryPropertyId);
    }
}