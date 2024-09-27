using NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Interfaces.ACL;

namespace NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade) : IExternalProfileService
{
    public async Task<Profile?> GetProfileById(int userId)
    {
        return await profilesContextFacade.GetProfileById(userId);
    }
}