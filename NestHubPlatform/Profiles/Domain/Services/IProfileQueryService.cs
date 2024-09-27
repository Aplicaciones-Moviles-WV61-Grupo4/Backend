using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Model.Queries;

namespace NestHubPlatform.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}