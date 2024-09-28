using NestHubPlatform.IAM.Application.Internal.OutboundServices;
using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Domain.Model.Commands;
using NestHubPlatform.IAM.Domain.Respositories;
using NestHubPlatform.IAM.Domain.Services;
using NestHubPlatform.IAM.Infrastructure.Hashing.BCrypt.Services;
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Repositories;
using NestHubPlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.IAM.Application.Internal.CommandServices;

public class UserCommandService (
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork, IProfileRepository profileRepository)
    : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        
        User.GlobalVariables.UserId = user.Id;
        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
    public async Task<User?> Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");

        List<Profile> profiles = await profileRepository.GetProfilesByDocumentNumber(command.DocumentNumber);
        if(profiles.Any())
            throw new Exception($"Document number {command.DocumentNumber} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync(); // Save the user first
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }

        var profile = new Profile(command.Name, command.FatherName, command.MotherName, command.DateOfBirth, command.DocumentNumber, command.Phone);
        profile.setUserId(user.Id); // Set the user id after the user has been saved
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync(); // Save the profile
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating profile: {e.Message}");
        }

        return user;
    }
}