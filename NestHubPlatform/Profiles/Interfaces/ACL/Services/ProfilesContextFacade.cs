using NestHubPlatform.Profiles.Domain.Model.Commands;
using NestHubPlatform.Profiles.Domain.Services;

namespace NestHubPlatform.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService) : IProfilesContextFacade
{
    public async Task<int> CreateProfile(string name, string fatherName, string motherName, string dateOfBirth, string documentNumber,
        string phone, int userId)
    {
        var createProfileCommand = new CreateProfileCommand(name, fatherName, motherName, dateOfBirth, documentNumber, phone, userId);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
}