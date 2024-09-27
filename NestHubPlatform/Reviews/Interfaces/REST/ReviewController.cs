using Microsoft.AspNetCore.Mvc;

using NestHubPlatform.Reviews.Domain.Model.Queries;
using NestHubPlatform.Reviews.Domain.Services;
using NestHubPlatform.Reviews.Interfaces.REST.Resources;
using NestHubPlatform.Reviews.Interfaces.REST.Transform;

namespace NestHubPlatform.Reviews.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ReviewController(
    IReviewCommandService reviewCommandService,
    IReviewQueryService reviewQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewResource createReviewResource)
    {
        var createReviewCommand =
            CreateReviewCommandFromResourceAssembler.ToCommandFromResource(createReviewResource);
        var review = await reviewCommandService.Handle(createReviewCommand);
        if (review is null) return BadRequest();
        var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = resource.Id }, resource);
    }
    
    [HttpGet("{reviewId}")]
    public async Task<IActionResult> GetReviewById([FromRoute] int reviewId)
    {
        var review = await reviewQueryService.Handle(new GetReviewByIdQuery(reviewId));
        if (review == null) return NotFound();
        var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var getAllReviewsQuery = new GetAllReviewsQuery();
        var reviews = await reviewQueryService.Handle(getAllReviewsQuery);
        var resources = reviews.Select(ReviewResourceFromEntityAssembler
            .ToResourceFromEntity);
        return Ok(resources);
    }
}