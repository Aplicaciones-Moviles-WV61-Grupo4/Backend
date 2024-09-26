using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration

        builder.Entity<Reservation>().HasKey(r => r.Id);
        builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reservation>().Property(r => r.LocalId);
        builder.Entity<Reservation>().Property(r => r.TotalAmount);
        builder.Entity<Reservation>().Property(r => r.NumberPerson);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        

    }
}