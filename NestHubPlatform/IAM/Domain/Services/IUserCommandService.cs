using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Domain.Model.Commands;

namespace NestHubPlatform.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    Task<User?> Handle(SignUpCommand command);
    
}