namespace NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL.Interfaces;

public interface IExternalLocalServices
{
    public Task<bool> LocalExists(int localId);
}