//using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Locals.Domain.Services;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Locals.Application.Internal.CommandServices;

public class LocalCommandService (ILocalRepository localRepository, ILocalCategoryRepository localCategoryRepository, IUnitOfWork unitOfWork) : ILocalCommandService
{
    
    public async Task<Local?> Handle(CreateLocalCommand command)
    {
        //var userAuthenticated = User.GlobalVariables.UserId;
        var local = new Local(command.District, command.Street, command.LocalType, command.Country, command.City, 
            command.Price, command.PhotoUrl, command.DescriptionMessage, command.LocalCategoryId, command.UserId);
        //local.UserId = userAuthenticated;
        await localRepository.AddAsync(local);
        await unitOfWork.CompleteAsync();
        var localCategory = await localCategoryRepository.FindByIdAsync(command.LocalCategoryId);
        local.LocalCategory = localCategory;
        return local;
    }
}