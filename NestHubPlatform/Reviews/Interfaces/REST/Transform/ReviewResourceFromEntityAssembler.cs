using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Interfaces.REST.Resources;

namespace NestHubPlatform.Reviews.Interfaces.REST.Transform;

public static class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity)
    {
        return new ReviewResource(entity.Id, entity.UserId, entity.LocalId, entity.Rating, entity.Comment);
    }
}