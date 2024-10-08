using System.Net.Mime;
using NestHubPlatform.Profiles.Domain.Model.Queries;
using NestHubPlatform.Profiles.Domain.Services;
using NestHubPlatform.Profiles.Interfaces.REST.Resources;
using NestHubPlatform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace NestHubPlatform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController(
    IProfileCommandService profileCommandService, 
    IProfileQueryService profileQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileResource createProfileResource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(createProfileResource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = resource.Id}, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var resources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{profileId}")]
    public async Task<IActionResult> GetProfileById([FromRoute] int profileId)
    {
        var profile = await profileQueryService.Handle(new GetProfileByIdQuery(profileId));
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateFarm([FromBody] UpdateProfileResource updateProfileResource)
    {
        var updateProfileCommand = UpdateProfileCommandFromResourceAssembler.ToCommandFromResource(updateProfileResource);
        var result = await profileCommandService.Handle(updateProfileCommand);
        return Ok(ProfileResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}