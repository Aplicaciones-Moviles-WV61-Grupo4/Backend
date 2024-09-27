using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Locals.Domain.Services;

namespace NestHubPlatform.Locals.Application.Internal.QueryServices;

public class LocalQueryService(ILocalRepository localRepository) : ILocalQueryService
{
    public async Task<IEnumerable<Local>> Handle(GetAllLocalsQuery query)
    {
        return await localRepository.ListAsync();
    }

    public async Task<Local?> Handle(GetLocalByIdQuery query)
    {
        return await localRepository.FindByIdAsync(query.LocalId);
    }

    public async Task<IEnumerable<Local>> Handle(GetAllLocalsByLocalCategoryIdQuery query)
    {
        return await localRepository.FindByLocalCategoryIdAsync(query.LocalCategoryId);
    }
}