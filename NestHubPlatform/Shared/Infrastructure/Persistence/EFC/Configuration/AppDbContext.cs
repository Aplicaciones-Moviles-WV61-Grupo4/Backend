using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Aggregates;
using NestHubPlatform.Locals.Domain.Model.Entities;
using NestHubPlatform.Payments.Domain.Model.Aggregates;
using NestHubPlatform.Payments.Domain.Model.Entities;
using NestHubPlatform.Profiles.Domain.Model.Aggregates;
using NestHubPlatform.Reservations.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Model.Aggregates;

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
        
        // LOCAL
        builder.Entity<LocalCategory>().HasKey(c => c.Id);
        builder.Entity<LocalCategory>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<LocalCategory>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        
        builder.Entity<LocalCategory>()
            .HasMany(c => c.Locals)
            .WithOne(t => t.LocalCategory)
            .HasForeignKey(t => t.LocalCategoryId)
            .HasPrincipalKey(t => t.Id);
        
        builder.Entity<Local>().HasKey(p => p.Id);
        builder.Entity<Local>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Local>().OwnsOne(p => p.Price,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.PriceNight).HasColumnName("PriceNight");
            });
        builder.Entity<Local>().OwnsOne(p => p.LType,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.TypeLocal).HasColumnName("TypeLocal");
            });
        builder.Entity<Local>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.District).HasColumnName("District");
                a.Property(s => s.Street).HasColumnName("Street");

            });
        builder.Entity<Local>().OwnsOne(p => p.Photo,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(g => g.PhotoUrlLink).HasColumnName("PhotoUrlLink");

            });
        builder.Entity<Local>().OwnsOne(p => p.Description,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(g => g.MessageDescription).HasColumnName("Description");

            });
        builder.Entity<Local>().OwnsOne(p => p.Place,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Country).HasColumnName("Country");
                a.Property(s => s.City).HasColumnName("City");

            });

        
        // RESERVATIONS
        
        builder.Entity<Reservation>().HasKey(r => r.Id);
        builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reservation>().Property(r => r.LocalId);
        builder.Entity<Reservation>().Property(r => r.TotalAmount);
        builder.Entity<Reservation>().Property(r => r.NumberPerson);
        
        // CONTACTS

        builder.Entity<Contact>().HasKey(p => p.Id);
        builder.Entity<Contact>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contact>().OwnsOne(c => c.EAdress,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(c => c.EmailAdress).HasColumnName("EmailAdress");
            });
        builder.Entity<Contact>().OwnsOne(p => p.CMessage,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.ContactMessage).HasColumnName("ContactMessage");
            });
        builder.Entity<Contact>().OwnsOne(p => p.FullName,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Name).HasColumnName("Name");
                a.Property(s => s.Lastname).HasColumnName("Lastname");

            });
        builder.Entity<Contact>().OwnsOne(p => p.NPhone,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(g => g.PhoneNumber).HasColumnName("PhoneNumber");

            });
        
        // REVIEWS
        builder.Entity<Review>().HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(r => r.LocalId);
        builder.Entity<Review>().Property(r => r.UserId);
        builder.Entity<Review>().Property(r => r.Comment);
        builder.Entity<Review>().Property(r => r.Rating);
        
        // PAYMENTS

        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.Amount);
        builder.Entity<Payment>().Property(p => p.Reservation);
        builder.Entity<Payment>().Property(p => p.InvoiceId);
        builder.Entity<Payment>().Property(p => p.Status);
        builder.Entity<Payment>().Property(p => p.PaymentMethod);
        
        // INVOICES
        
        builder.Entity<Invoice>().HasKey(i => i.Id);
        builder.Entity<Invoice>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Invoice>().Property(i => i.PaymentId).IsRequired();
        builder.Entity<Invoice>().Property(i => i.Amount).IsRequired();
        builder.Entity<Invoice>().Property(i => i.Date).IsRequired();
        
        builder.Entity<Invoice>()
            .HasMany(i => i.Payments)
            .WithOne(p => p.Invoice)
            .HasForeignKey(p => p.InvoiceId)
            .HasPrincipalKey(i => i.Id);
        
        // PROFILES 
        
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Name).HasColumnName("FirstName");
                n.Property(p => p.FatherName).HasColumnName("FatherName");
                n.Property(p => p.MotherName).HasColumnName("MotherName");
            });
        builder.Entity<Profile>().OwnsOne(p => p.PhoneN,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber");
            });
        builder.Entity<Profile>().OwnsOne(p => p.DocumentN,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.NumberDocument).HasColumnName("NumberDocument");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Birth,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.BirthDate).HasColumnName("BirthDate");
            });
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        

    }
}