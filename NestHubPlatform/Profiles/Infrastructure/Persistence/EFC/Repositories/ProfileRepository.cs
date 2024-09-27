
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NestHubPlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public new async Task<Profile?> FindByIdAsync(int id) =>
        await Context.Set<Profile>().Include(t => t.Id)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Profile>> ListAsync()
    {
        return await Context.Set<Profile>()
            .Include(profile => profile.Id)
            .ToListAsync();
    }
}