using System.Configuration;
using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.ValueObjects;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NestHubPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;

public class LocalRepository(AppDbContext context) : BaseRepository<Local>(context), ILocalRepository
{
    public new async Task<Local?> FindByIdAsync(int id) =>
        await Context.Set<Local>().Include(t => t.LocalCategory)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Local>> ListAsync()
    {
        return await Context.Set<Local>()
            .Include(local => local.LocalCategory)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Local>> FindByLocalCategoryIdAsync(int localCategoryId)
    {
        return await Context.Set<Local>()
            .Include(local => local.LocalCategory)
            .Where(local => local.LocalCategoryId == localCategoryId)
            .ToListAsync();
    }
}