namespace NestHubPlatform.Contacts.Domain.Model.Commands;

public record CreateContactCommand(string Name, string Lastname, string Message, string Email, string Phone, int propertyId);