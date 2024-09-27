using NestHubPlatform.Profiles.Domain.Model.Aggregates;

namespace NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL.Interfaces;

public interface IExternalProfileService
{
    Task<Profile?> GetProfileById(int userId);
}