using NestHubPlatform.Reviews.Domain.Model.Aggregates;

namespace NestHubPlatform.Reviews.Interfaces.ACL;

public interface IReviewContextFacade
{
    Task<IEnumerable<Review>> GetAllReviewsByLocalId(int id);
}