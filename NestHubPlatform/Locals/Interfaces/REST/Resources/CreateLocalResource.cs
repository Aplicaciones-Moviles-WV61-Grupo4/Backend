namespace NestHubPlatform.Locals.Interfaces.REST.Resources;

public record CreateLocalResource(string District, string Street, string Title, string City, 
    int Price, string PhotoUrl, string DescriptionMessage, int LocalCategoryId, int UserId);