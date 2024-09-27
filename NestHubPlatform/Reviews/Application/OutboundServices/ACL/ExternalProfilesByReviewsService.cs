using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Interfaces.ACL;
using NestHubPlatform.Reviews.Application.OutboundServices.ACL.Interfaces;

namespace NestHubPlatform.Reviews.Application.OutboundServices.ACL;

public class ExternalProfilesByReviewsService(IProfilesContextFacade profilesContextFacade) : IExternalProfilesByReviewsService
{
    public async Task<Profile?> GetProfileById(int userId)
    {
        return await profilesContextFacade.GetProfileById(userId);
    }
}