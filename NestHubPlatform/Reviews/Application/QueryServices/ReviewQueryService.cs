using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Model.Queries;
using NestHubPlatform.Reviews.Domain.Repositories;
using NestHubPlatform.Reviews.Domain.Services;

namespace NestHubPlatform.Reviews.Application.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository) : IReviewQueryService
{
    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query)
    {
        return await reviewRepository.ListAsync();
    }
}