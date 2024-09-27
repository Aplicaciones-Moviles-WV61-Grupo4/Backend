using NestHubPlatform.Contacts.Domain.Model.ValueObjects;

namespace NestHubPlatform.Contacts.Interfaces.REST.Resource;

public record ContactResource(int Id, string Email, string Message, string NameSurname, string Phone, int  propertyId, int UserId);