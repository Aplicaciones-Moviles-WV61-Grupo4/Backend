namespace NestHubPlatform.Reviews.Domain.Model.Commands;

public record CreateReviewCommand(int UserId, int LocalId, int Rating, string Comment);
