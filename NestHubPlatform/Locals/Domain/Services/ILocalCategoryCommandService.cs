using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Domain.Model.Entities;

namespace NestHubPlatform.Locals.Domain.Services;

public interface ILocalCategoryCommandService
{
    public Task<LocalCategory?> Handle(CreateLocalCategoryCommand command);
}