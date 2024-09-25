using Microsoft.AspNetCore.Mvc;
using NestHubPlatform.Reservations.Domain.Model.Queries;
using NestHubPlatform.Reservations.Domain.Services;
using NestHubPlatform.Reservations.Interfaces.REST.Resources;
using NestHubPlatform.Reservations.Interfaces.REST.Transform;

namespace NestHubPlatform.Reservations.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ReservationController(
    IReservationCommandService reservationCommandService,
    IReservationQueryService reservationQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationResource createReservationResource)
    {
        var createReservationCommand =
            CreateReservationCommandFromResourceAssembler.ToCommandFromResource(createReservationResource);
        var reservation = await reservationCommandService.Handle(createReservationCommand);
        if (reservation is null) return BadRequest();
        var resource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        
        return CreatedAtAction(nameof(GetReservationById), new { reservationId = resource.Id }, resource);
    }
    
    [HttpGet("{reservationId}")]
    public async Task<IActionResult> GetReservationById([FromRoute] int reservationId)
    {
        var reservation = await reservationQueryService.Handle(new GetReservationByIdQuery(reservationId));
        if (reservation == null) return NotFound();
        var resource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReservations()
    {
        var getAllReservationsQuery = new GetAllReservationsQuery();
        var reservations = await reservationQueryService.Handle(getAllReservationsQuery);
        var resources = reservations.Select(ReservationResourceFromEntityAssembler
            .ToResourceFromEntity);
        return Ok(resources);
    }
}