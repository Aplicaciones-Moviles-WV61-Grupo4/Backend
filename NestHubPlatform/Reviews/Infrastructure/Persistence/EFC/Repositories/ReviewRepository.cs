using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Reviews.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context)
    : BaseRepository<Review>(context), IReviewRepository
{
    public async Task<IEnumerable<Review>> FindByLocalIdAsync(int localId)
    {
        return await Context.Set<Review>()
            .Where(review => review.LocalId == localId)
            .ToListAsync();
    }
}