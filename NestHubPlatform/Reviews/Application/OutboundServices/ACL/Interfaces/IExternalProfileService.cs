using NestHubPlatform.Profiles.Domain.Model.Aggregates;

namespace NestHubPlatform.Reviews.Application.OutboundServices.ACL.Interfaces;

public interface IExternalProfilesByReviewsService
{
    Task<Profile?> GetProfileById(int userId);
}