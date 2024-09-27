
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Profiles.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NestHubPlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
}