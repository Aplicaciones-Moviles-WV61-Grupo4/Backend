using NestHubPlatform.Reviews.Domain.Model.Commands;
using NestHubPlatform.Reviews.Interfaces.REST.Resources;

namespace NestHubPlatform.Reviews.Interfaces.REST.Transform;

public static class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
    {
        return new CreateReviewCommand(resource.UserId, resource.LocalId, resource.Rating, resource.Comment);
    }
}