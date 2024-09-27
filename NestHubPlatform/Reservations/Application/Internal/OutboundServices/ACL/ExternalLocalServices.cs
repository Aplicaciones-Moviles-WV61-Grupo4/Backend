using NestHubPlatform.Locals.Interfaces.ACL;
using NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL.Interfaces;

namespace NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL;

public class ExternalLocalServices(ILocalsContextFacade localsContextFacade): IExternalLocalServices
{
    public async Task<bool> LocalExists(int localId)
    {
        return await localsContextFacade.LocalExists(localId);
    }
}