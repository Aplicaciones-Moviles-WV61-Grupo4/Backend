using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.ValueObjects;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Locals.Domain.Repositories;

public interface ILocalRepository : IBaseRepository<Local>
{
    Task<IEnumerable<Local>> FindByLocalCategoryIdAsync(int localCategoryId);
}