using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Domain.Model.Entities;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Locals.Domain.Services;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Locals.Application.Internal.CommandServices;

public class LocalCategoryCommandService(ILocalCategoryRepository localCategoryRepository, IUnitOfWork unitOfWork)
:ILocalCategoryCommandService
{
    public async Task<LocalCategory?> Handle(CreateLocalCategoryCommand command)
    {
        var localCategory = new LocalCategory(command.Name);
        await localCategoryRepository.AddAsync(localCategory);
        await unitOfWork.CompleteAsync();
        return localCategory;
    }
}