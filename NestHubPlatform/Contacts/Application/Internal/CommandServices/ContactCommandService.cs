using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Domain.Model.Commands;
using NestHubPlatform.Contacts.Domain.Repositories;
using NestHubPlatform.Contacts.Domain.Services;
//using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.Shared.Domain.Repositories;

namespace NestHubPlatform.Contacts.Application.Internal.CommandServices;

public class ContactCommandService (IContactRepository contactRepository, IUnitOfWork unitOfWork) : IContactCommandService
{
    public async Task<Contact?> Handle(CreateContactCommand command)
    {
        //var userAuthenticated = User.GlobalVariables.UserId;
        var contact = new Contact(command.Name, command.Lastname, command.Message, command.Email, command.Phone, command.propertyId);
        //contact.UserId = userAuthenticated;
        await contactRepository.AddAsync(contact);
        await unitOfWork.CompleteAsync();
        return contact;
    }
    
}