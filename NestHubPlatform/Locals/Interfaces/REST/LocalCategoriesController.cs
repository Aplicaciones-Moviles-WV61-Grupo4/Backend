using System.Net.Mime;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;
using AlquilaFacilPlatform.Locals.Domain.Services;
using AlquilaFacilPlatform.Locals.Interfaces.REST.Resources;
using AlquilaFacilPlatform.Locals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlquilaFacilPlatform.Locals.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class LocalCategoriesController(
    ILocalCategoryCommandService localCategoryCommandService,
    ILocalCategoryQueryService localCategoryQueryService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateLocalCategory(
        [FromBody] CreateLocalCategoryResource createLocalCategoryResource)
    {
        var createLocalCategoryCommand =
            CreateLocalCategoryCommandFromResourceAssembler.ToCommandFromResource(createLocalCategoryResource);
        var localCategory = await localCategoryCommandService.Handle(createLocalCategoryCommand);
        if (localCategory is null) return BadRequest();
        var resource = LocalCategoryResourceFromEntityAssembler.ToResourceFromEntity(localCategory);
        return CreatedAtAction(nameof(GetLocalCategoryById), new { localCategoryId = resource.Id }, resource);
    }
    
    [HttpGet("{localCategoryId:int}")]
    public async Task<IActionResult> GetLocalCategoryById(int localCategoryId)
    {
        var getLocalCategoryByIdQuery = new GetLocalCategoryByIdQuery(localCategoryId);
        var localCategory = await localCategoryQueryService.Handle(getLocalCategoryByIdQuery);
        var resource = LocalCategoryResourceFromEntityAssembler.ToResourceFromEntity(localCategory);
        return Ok(resource);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllLocalCategories()
    {
        var getAllLocalCategoriesQuery = new GetAllLocalCategoriesQuery();
        var localcategories = await localCategoryQueryService.Handle(getAllLocalCategoriesQuery);
        var resources = localcategories.
            Select(LocalCategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}