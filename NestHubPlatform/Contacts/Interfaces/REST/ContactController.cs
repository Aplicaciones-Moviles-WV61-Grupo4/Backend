using System.Net.Mime;
using NestHubPlatform.Contacts.Domain.Model.Aggregates;
using NestHubPlatform.Contacts.Domain.Model.Queries;
using NestHubPlatform.Contacts.Domain.Repositories;
using NestHubPlatform.Contacts.Domain.Services;
using NestHubPlatform.Contacts.Interfaces.REST.Resource;
using NestHubPlatform.Contacts.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace NestHubPlatform.Contacts.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ContactController(IContactCommandService contactCommandService, IContactQueryService contactQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactResource resource)
    {
        var createContactCommand = CreateContactCommandFromResourceAssembler.ToCommandFromResources(resource);
        var contact = await contactCommandService.Handle(createContactCommand);
        if (contact is null) return BadRequest();
        var contactResource = ContactResourceFromEntityAssembler.ToResourceFromEntity(contact);
        return CreatedAtAction(nameof(GetContactById), new { contactId = contactResource.Id }, contactResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var getAllContactQuery = new GetAllContactQuery();
        var contacts = await contactQueryService.Handle(getAllContactQuery);
        var contactResources = contacts.Select(ContactResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(contactResources);
    }

    [HttpGet("{contactId:int}")]
    public async Task<IActionResult> GetContactById(int contactId)
    {
        var getContactByIdQuery = new GetContactByIdQuery(contactId);
        var contact = await contactQueryService.Handle(getContactByIdQuery);
        if (contact == null) return NotFound();
        var contactResource = ContactResourceFromEntityAssembler.ToResourceFromEntity(contact);
        return Ok(contactResource);
    }
    
    [HttpGet("{propertyId}")]
    public async Task<IActionResult> GetContactsByPropertyId(int propertyId)
    {
        var getContactsByPropertyIdQuery = new GetContactsBypropertyIdQuery(propertyId);
        var contacts = await contactQueryService.Handle(getContactsByPropertyIdQuery);
        
        var contactResources = new List<ContactResource>();
        foreach (Contact contact in contacts)
        {
            contactResources.Add(ContactResourceFromEntityAssembler.ToResourceFromEntity(contact));
        }
    
        return Ok(contactResources);
    }
    
    
}