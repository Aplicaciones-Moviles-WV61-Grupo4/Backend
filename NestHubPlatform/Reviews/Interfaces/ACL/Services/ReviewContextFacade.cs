using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Model.Queries;
using NestHubPlatform.Reviews.Domain.Services;

namespace NestHubPlatform.Reviews.Interfaces.ACL.Services;

public class ReviewContextFacade(IReviewQueryService reviewQueryService) : IReviewContextFacade
{
    public Task<IEnumerable<Review>> GetAllReviewsByLocalId(int id)
    {
        return reviewQueryService.Handle(new GetReviewsByLocalIdQuery(id));
    }
}