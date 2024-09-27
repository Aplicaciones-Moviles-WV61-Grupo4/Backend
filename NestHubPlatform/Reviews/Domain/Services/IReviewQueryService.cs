using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Model.Queries;

namespace NestHubPlatform.Reviews.Domain.Services;

public interface IReviewQueryService
{
    Task<Review?> Handle(GetReviewByIdQuery query);
    Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query);
}