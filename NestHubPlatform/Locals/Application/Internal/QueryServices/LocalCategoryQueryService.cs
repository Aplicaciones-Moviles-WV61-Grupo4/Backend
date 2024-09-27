using NestHubPlatform.Locals.Domain.Model.Entities;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Locals.Domain.Services;

namespace NestHubPlatform.Locals.Application.Internal.QueryServices;

public class LocalCategoryQueryService(ILocalCategoryRepository localCategoryRepository) : ILocalCategoryQueryService
{
    public async Task<LocalCategory?> Handle(GetLocalCategoryByIdQuery query)
    {
        return await localCategoryRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<LocalCategory>> Handle(GetAllLocalCategoriesQuery query)
    {
        return await localCategoryRepository.ListAsync();
    }
}