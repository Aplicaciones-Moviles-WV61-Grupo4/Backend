using NestHubPlatform.Locals.Domain.Model.Entities;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NestHubPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;

public class LocalCategoryRepository(AppDbContext context)
    : BaseRepository<LocalCategory>(context), ILocalCategoryRepository;
