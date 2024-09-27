using NestHubPlatform.Reviews.Domain.Model.Aggregates;

namespace NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL.Interfaces;

public interface IExternalReviewService
{
    public Task<IEnumerable<Review>> GetAllReviewsByLocalId(int id);
}