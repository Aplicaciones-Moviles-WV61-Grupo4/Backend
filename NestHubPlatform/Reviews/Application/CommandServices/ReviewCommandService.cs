using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Application.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Model.Commands;
using NestHubPlatform.Reviews.Domain.Repositories;
using NestHubPlatform.Reviews.Domain.Services;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Reviews.Application.CommandServices;

public class ReviewCommandService(
    IReviewRepository reviewRepository,
    IExternalProfilesByReviewsService externalProfilesByReviewsService,
    IUnitOfWork unitOfWork) : IReviewCommandService
{
    public async Task<Review?> Handle(CreateReviewCommand command)
    {
        var review = new Review(command.UserId, command.LocalId, command.Rating, command.Comment);
        await reviewRepository.AddAsync(review);
        await unitOfWork.CompleteAsync();

        return review;
    }
}