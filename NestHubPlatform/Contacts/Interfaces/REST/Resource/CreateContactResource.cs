namespace NestHubPlatform.Contacts.Interfaces.REST.Resource;

public record CreateContactResource(string Name, string Lastname, string Message, string Email, string Phone, int propertyId);