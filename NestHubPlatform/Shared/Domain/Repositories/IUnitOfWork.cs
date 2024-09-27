namespace NestHubPlatform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}