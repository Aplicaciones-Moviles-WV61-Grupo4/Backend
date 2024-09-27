using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Commands;

namespace NestHubPlatform.Locals.Domain.Services;

public interface ILocalCommandService
{
    Task<Local?> Handle(CreateLocalCommand command);
}