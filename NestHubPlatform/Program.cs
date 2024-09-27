using AlquilaFacilPlatform.Locals.Application.Internal.CommandServices;
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
using NestHubPlatform.Reservations.Application.Internal.CommandServices;
using NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL;
using NestHubPlatform.Reservations.Application.Internal.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Reservations.Application.Internal.QueryServices;
using NestHubPlatform.Reservations.Domain.Repositories;
using NestHubPlatform.Reservations.Domain.Services;
using NestHubPlatform.Reservations.Infrastructure.Persistence.EFC.Repositories;
using NestHubPlatform.Reviews.Application.CommandServices;
using NestHubPlatform.Reviews.Application.QueryServices;
using NestHubPlatform.Reviews.Domain.Repositories;
using NestHubPlatform.Reviews.Domain.Services;
using NestHubPlatform.Reviews.Infrastructure.Persistence.EFC.Repositories;

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

// CONTACTS

// REVIEWS
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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