using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Model.Commands;

namespace NestHubPlatform.Reviews.Domain.Services;

public interface IReviewCommandService
{
    public Task<Review?> Handle(CreateReviewCommand command);
}