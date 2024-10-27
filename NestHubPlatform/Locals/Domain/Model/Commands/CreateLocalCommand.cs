namespace NestHubPlatform.Locals.Domain.Model.Commands;

public record CreateLocalCommand(
    string Title, string District, string Street, string City, int Price, string PhotoUrl,
    string DescriptionMessage, int LocalCategoryId, int UserId);