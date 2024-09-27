using System.Net.Mime;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Services;
using NestHubPlatform.Locals.Interfaces.REST.Resources;
using NestHubPlatform.Locals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL.Interfaces;

namespace NestHubPlatform.Locals.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class LocalsController(
    ILocalCommandService localCommandService, 
    ILocalQueryService localQueryService,
    IExternalReviewService reviewService,
    IExternalProfileService profileService) 
    :ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocal(CreateLocalResource resource)
    {
        var createLocalCommand = CreateLocalCommandFromResourceAssembler.ToCommandFromResources(resource);
        var local = await localCommandService.Handle(createLocalCommand);
        if (local is null) return BadRequest();
        var localResource = LocalResourceFromEntityAssembler.ToResourceFromEntity(local);
        return CreatedAtAction(nameof(GetLocalById), new { localId = localResource.Id }, localResource);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllLocals()
    {
        var getAllLocalsQuery = new GetAllLocalsQuery();
        var locals = await localQueryService.Handle(getAllLocalsQuery);
        var localResources = locals.Select(LocalResourceFromEntityAssembler.ToResourceFromEntity);

        var localsWithDetails = new List<object>();

        foreach (var localResource in localResources)
        {
            var reviews = await reviewService.GetAllReviewsByLocalId(localResource.Id);

            // Obtener el perfil del dueño del local
            var profile = await profileService.GetProfileById(localResource.UserId);
            var localOwnerName = profile?.FullName; // Asegúrate de que el perfil no sea nulo

            localsWithDetails.Add(new
            {
                Local = localResource,
                Reviews = reviews,
                LocalOwnerName = localOwnerName // Añadir el nombre del dueño
            });
        }

        return Ok(localsWithDetails);
    }

    [HttpGet("{localId:int}")]
    public async Task<IActionResult> GetLocalById(int localId)
    {
        var getLocalByIdQuery = new GetLocalByIdQuery(localId);
        var local = await localQueryService.Handle(getLocalByIdQuery);
        if (local == null) return NotFound();
        var localResource = LocalResourceFromEntityAssembler.ToResourceFromEntity(local);

        var reviews = await reviewService.GetAllReviewsByLocalId(localResource.Id);

        var profile = await profileService.GetProfileById(localResource.UserId);

        var localOwnerName  = profile?.FullName;

        var response = new
        {
            Local = localResource,
            Reviews = reviews,
            LocalOwnerName = localOwnerName  
        };

        return Ok(response);
    }

}