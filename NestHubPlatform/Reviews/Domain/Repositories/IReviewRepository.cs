using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Reviews.Domain.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<IEnumerable<Review>> FindByLocalIdAsync(int localId);
}