namespace NestHubPlatform.Locals.Interfaces.ACL;

public interface ILocalsContextFacade
{
    Task<int> CreateLocal(string title, string district, string street, string city,
        int price, string photoUrl, string descriptionMessage, int localCategoryId, int userId);
    Task<bool> LocalExists(int localId);
}