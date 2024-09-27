using System.Net.Mime;
using NestHubPlatform.Locals.Domain.Model.Queries;
using NestHubPlatform.Locals.Domain.Services;
using NestHubPlatform.Locals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace NestHubPlatform.Locals.Interfaces.REST;


[ApiController]
[Route("/api/v1/categories/{localCategoryId}/locals")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("LocalCategories")]
public class LocalCategoryLocalsController(ILocalQueryService localQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLocalsByLocalCategoryId([FromRoute] int localCategoryId)
    {
        var getAllLocalsByLocalCategoryIdQuery = new GetAllLocalsByLocalCategoryIdQuery(localCategoryId);
        var locals = await localQueryService.Handle(getAllLocalsByLocalCategoryIdQuery);
        var resources = locals.Select(LocalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}