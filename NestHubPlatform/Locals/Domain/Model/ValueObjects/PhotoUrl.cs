namespace NestHubPlatform.Locals.Domain.Model.ValueObjects;

public record PhotoUrl(string PhotoUrlLink)
{
    public PhotoUrl() : this(string.Empty)
    {
        
    }
}