using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Model.Commands;
using NestHubPlatform.Profiles.Domain.Model.Queries;
using NestHubPlatform.Profiles.Domain.Services;

namespace NestHubPlatform.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    public async Task<int> CreateProfile(string name, string fatherName, string motherName, string dateOfBirth, string documentNumber,
        string phone, int userId)
    {
        var createProfileCommand = new CreateProfileCommand(name, fatherName, motherName, dateOfBirth, documentNumber, phone, userId);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    public async Task<Profile?> GetProfileById(int userId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(userId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        return profile;
    }
}