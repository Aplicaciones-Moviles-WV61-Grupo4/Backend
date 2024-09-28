using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.IAM.Domain.Respositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync (string username);
    bool ExistsByUsername(string username);
}