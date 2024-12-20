using System.Net.Mime;
using NestHubPlatform.IAM.Application.Internal.CommandServices;
using NestHubPlatform.IAM.Domain.Model.Aggregates;
using NestHubPlatform.IAM.Domain.Model.Commands;
using NestHubPlatform.IAM.Domain.Model.Queries;
using NestHubPlatform.IAM.Domain.Services;
using NestHubPlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using NestHubPlatform.IAM.Interfaces.REST.Resources;
using NestHubPlatform.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace NestHubPlatform.IAM.Interfaces.REST;

/**
 * <summary>
 *     The users controller
 * </summary>
 * <remarks>
 *     This class is used to handle user requests
 * </remarks>
 */

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(
    IUserQueryService userQueryService,
    IUserCommandService userCommandService
) : ControllerBase
{
    /**
     * <summary>
     *     Get user by id endpoint. It allows to get a user by id
     * </summary>
     * <param name="id">The user id</param>
     * <returns>The user resource</returns>
     */
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user!);
        return Ok(userResource);
    }

    /**
     * <summary>
     *     Get all users endpoint. It allows to get all users
     * </summary>
     * <returns>The user resources</returns>
     */
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}
