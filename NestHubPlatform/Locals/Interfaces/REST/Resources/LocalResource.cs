using NestHubPlatform.Reviews.Domain.Model.Aggregates;

namespace NestHubPlatform.Locals.Interfaces.REST.Resources;

public record LocalResource(int Id, string StreetAddress, string CityPlace, int NightPrice, 
    string PhotoUrl, string Title, string DescriptionMessage, LocalCategoryResource LocalCategory, int UserId);