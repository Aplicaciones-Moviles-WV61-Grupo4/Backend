using System.Net.Mime;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Services;
using NestHubPlatform.Locals.Interfaces.REST.Resources;
using NestHubPlatform.Locals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NestHubPlatform.Locals.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class LocalsController(ILocalCommandService localCommandService, ILocalQueryService localQueryService)
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
        return Ok(localResources);
    }

    [HttpGet("{localId:int}")]
    public async Task<IActionResult> GetLocalById(int localId)
    {
        var getLocalByIdQuery = new GetLocalByIdQuery(localId);
        var local = await localQueryService.Handle(getLocalByIdQuery);
        if (local == null) return NotFound();
        var localResource = LocalResourceFromEntityAssembler.ToResourceFromEntity(local);
        return Ok(localResource);
    }
    
}