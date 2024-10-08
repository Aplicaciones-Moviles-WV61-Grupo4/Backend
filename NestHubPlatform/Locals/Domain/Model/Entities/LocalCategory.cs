using NestHubPlatform.Locals.Domain.Model.Aggregates;

namespace NestHubPlatform.Locals.Domain.Model.Entities;

public class LocalCategory
{
    public LocalCategory()
    {
        Name = string.Empty;
    }

    public LocalCategory(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Local> Locals { get; }
}