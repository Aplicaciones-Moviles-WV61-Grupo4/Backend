using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Services;

namespace NestHubPlatform.Locals.Interfaces.ACL.Services;

public class LocalsContextFacade(ILocalCommandService localCommandService,
    ILocalQueryService localQueryService) : ILocalsContextFacade
{
    public async Task<int> CreateLocal(string title, string district, string street, string city, 
        int price, string photoUrl, string descriptionMessage, int localCategoryId, int userId)
    {
        var createLocalCommand = new CreateLocalCommand(title, district, street, city, price, photoUrl, descriptionMessage, localCategoryId, userId);
        var local = await localCommandService.Handle(createLocalCommand);
        return local?.Id ?? 0;
    }

    public async Task<bool> LocalExists(int localId)
    {
        var local = await localQueryService.Handle(new GetLocalByIdQuery(localId));
        return local != null;
    }
}