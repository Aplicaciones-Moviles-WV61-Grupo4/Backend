using NestHubPlatform.Locals.Domain.Model.Commands;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Services;

namespace NestHubPlatform.Locals.Interfaces.ACL.Services;

public class LocalsContextFacade(ILocalCommandService localCommandService,
    ILocalQueryService localQueryService) : ILocalsContextFacade
{
    private ILocalsContextFacade _localsContextFacadeImplementation;

    public async Task<int> CreateLocal(string district, string street, string localType, string country, string city, 
                int price, string photoUrl, string descriptionMessage, int localCategoryId)
    {
        var createLocalCommand = new CreateLocalCommand(district, street, localType, country, city, price, photoUrl, descriptionMessage ,localCategoryId);
        var local = await localCommandService.Handle(createLocalCommand);
        return local?.Id ?? 0;
    }

    public async Task<bool> LocalExists(int localId)
    {
        var local = await localQueryService.Handle(new GetLocalByIdQuery(localId));
        return local != null;
    }
}