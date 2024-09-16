
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Model.Commands;

namespace NestHubPlatform.Profiles.Domain.Services;

public interface IProfileCommandService
{
    public Task<Profile?> Handle(CreateProfileCommand command);
    public Task<Profile> Handle(UpdateProfileCommand command);
}