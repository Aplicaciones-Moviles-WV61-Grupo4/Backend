using NestHubPlatform.Locals.Domain.Model.Entities;
using NestHubPlatform.Locals.Domain.Model.Queries;

namespace NestHubPlatform.Locals.Domain.Services;

public interface ILocalCategoryQueryService
{
    Task<LocalCategory?> Handle(GetLocalCategoryByIdQuery query);

    Task<IEnumerable<LocalCategory>> Handle(GetAllLocalCategoriesQuery query);
}