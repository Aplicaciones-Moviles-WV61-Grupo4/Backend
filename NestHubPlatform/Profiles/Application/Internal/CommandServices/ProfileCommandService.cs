
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Model.Commands;
using NestHubPlatform.Profiles.Domain.Repositories;
using NestHubPlatform.Profiles.Domain.Services;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command.Name, command.FatherName, command.MotherName, command.DateOfBirth, 
            command.DocumentNumber, command.Phone, command.UserId);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }

    public async Task<Profile> Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.FindByIdAsync(command.UserId);
        if (profile == null)
        {
            throw new Exception("Profile with ID does not exist");
        }

        profile.Update(command);
        await unitOfWork.CompleteAsync();
        return profile;
    }
}