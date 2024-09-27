using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Queries;

namespace NestHubPlatform.Locals.Domain.Services;

public interface ILocalQueryService
{
    Task<IEnumerable<Local>> Handle(GetAllLocalsQuery query);
    Task<Local?> Handle(GetLocalByIdQuery query);
    Task<IEnumerable<Local>> Handle(GetAllLocalsByLocalCategoryIdQuery query);
}