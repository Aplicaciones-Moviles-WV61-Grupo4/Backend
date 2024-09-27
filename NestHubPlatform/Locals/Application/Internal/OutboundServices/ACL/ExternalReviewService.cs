using NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL.Interfaces;
using NestHubPlatform.Reviews.Domain.Model.Aggregates;
using NestHubPlatform.Reviews.Interfaces.ACL;

namespace NestHubPlatform.Locals.Application.Internal.OutboundServices.ACL;

public class ExternalReviewService(IReviewContextFacade reviewContextFacade) : IExternalReviewService
{
    public async Task<IEnumerable<Review>> GetAllReviewsByLocalId(int id)
    {
        return await reviewContextFacade.GetAllReviewsByLocalId(id);
    }
}