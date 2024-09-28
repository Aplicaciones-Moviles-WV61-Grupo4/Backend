using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Domain.Model.Queries;

namespace NestHubPlatform.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}