namespace NestHubPlatform.Reviews.Interfaces.REST.Resources;

public record CreateReviewResource(int UserId, int LocalId, int Rating, string Comment);