using NestHubPlatform.Locals.Application.Internal.CommandServices;
using NestHubPlatform.Locals.Application.Internal.CommandServices;
using NestHubPlatform.Locals.Application.Internal.QueryServices;
using NestHubPlatform.Locals.Domain.Repositories;
using NestHubPlatform.Locals.Domain.Services;
using NestHubPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;
using NestHubPlatform.Locals.Interfaces.ACL;
using NestHubPlatform.Locals.Interfaces.ACL.Services;
using NestHubPlatform.Shared.Domain.Repositories;
using NestHubPlatform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NestHubPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NestHubPlatform.Contacts.Application.Internal.CommandServices;
using NestHubPlatform.Contacts.Application.Internal.QueryService;
using NestHubPlatform.Contacts.Domain.Repositories;
using NestHubPlatform.Contacts.Domain.Services;
using NestHubPlatform.Contacts.Infrastructure.Persistence.EFC.Repositories;
using NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL;
using NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Locals.Interfaces.REST.Transform;
using NestHubPlatform.Payments.Application.Internal.CommandServices;
using NestHubPlatform.Payments.Application.Internal.QueryServices;
using NestHubPlatform.Payments.Domain.Repositories;
using NestHubPlatform.Payments.Domain.Services;
using NestHubPlatform.Payments.Infrastructure.EFC.Repositories;
using NestHubPlatform.Payments.Interfaces.ACL;
using NestHubPlatform.Payments.Interfaces.ACL.Services;
using NestHubPlatform.Profiles.Application.Internal.CommandServices;
using NestHubPlatform.Profiles.Application.Internal.QueryServices;
using NestHubPlatform.Profiles.Domain.Repositories;
using NestHubPlatform.Profiles.Domain.Services;
using NestHubPlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using NestHubPlatform.Profiles.Interfaces.ACL;
using NestHubPlatform.Profiles.Interfaces.ACL.Services;
using NestHubPlatform.Reservations.Application.Internal.CommandServices;
using NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL;
using NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Reservations.Application.Internal.QueryServices;
using NestHubPlatform.Reservations.Domain.Repositories;
using NestHubPlatform.Reservations.Domain.Services;
using NestHubPlatform.Reservations.Infrastructure.Persistence.EFC.Repositories;
using NestHubPlatform.Reviews.Application.CommandServices;
using NestHubPlatform.Reviews.Application.OutboundServices.ACL;
using NestHubPlatform.Reviews.Application.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Reviews.Application.QueryServices;
using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Domain.Repositories;
using NestHubPlatform.Reviews.Domain.Services;
using NestHubPlatform.Reviews.Infrastructure.Persistence.EFC.Repositories;
using NestHubPlatform.Reviews.Interfaces.ACL;
using NestHubPlatform.Reviews.Interfaces.ACL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "NestHubPlatform",
                Version = "v1",
                Description = "NestHub Platform ",
                TermsOfService = new Uri("https://nesthub.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "NestHub Platform",
                    Email = "contact@nesthub.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles Bounded Context Injection Configuration

// LOCALS
builder.Services.AddScoped<ILocalCommandService, LocalCommandService>();
builder.Services.AddScoped<ILocalQueryService, LocalQueryService>();
builder.Services.AddScoped<ILocalsContextFacade, LocalsContextFacade>();
builder.Services.AddScoped<ILocalRepository, LocalRepository>();
builder.Services.AddScoped<ILocalCategoryRepository, LocalCategoryRepository>();
builder.Services.AddScoped<ILocalCategoryCommandService, LocalCategoryCommandService>();
builder.Services.AddScoped<ILocalCategoryQueryService, LocalCategoryQueryService>();

// RESERVATIONS

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationCommandService, ReservationCommandService>();
builder.Services.AddScoped<IReservationQueryService, ReservationQueryService>();
builder.Services.AddScoped<IExternalLocalServices, ExternalLocalServices>();

// PAYMENTS

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();
builder.Services.AddScoped<IPaymentContextFacade, PaymentContextFacade>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceCommandService, InvoiceCommandService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceQueryService, InvoiceQueryService>();

// CONTACTS

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactCommandService, ContactCommandService>();
builder.Services.AddScoped<IContactQueryService, ContactQueryService>();


// PROFILES

builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();
builder.Services.AddScoped<IExternalProfileService, ExternalProfileService>();

// REVIEWS
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();
builder.Services.AddScoped<IReviewContextFacade, ReviewContextFacade>();
builder.Services.AddScoped<IExternalReviewService, ExternalReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IExternalProfilesByReviewsService, ExternalProfilesByReviewsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NestHub API v1");
    c.RoutePrefix = "swagger"; // Muestra Swagger en /swagger

});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();