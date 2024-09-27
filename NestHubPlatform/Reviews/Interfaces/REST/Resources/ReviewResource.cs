using NestHubPlatform.Profiles.Domain.Model.Aggregates;

namespace NestHubPlatform.Reviews.Interfaces.REST.Resources;

public record ReviewResource(int Id, int UserId, int LocalId, int Rating, string Comment);