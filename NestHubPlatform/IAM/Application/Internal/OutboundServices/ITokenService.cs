using NestHubPlatform.IAM.Domain.Model.Aggregates;

namespace NestHubPlatform.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}