using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Domain.Model.Queries;
using NestHubPlatform.IAM.Domain.Respositories;
using NestHubPlatform.IAM.Domain.Services;

namespace NestHubPlatform.IAM.Application.Internal.QueryServices;

public class UserQueryService (IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}