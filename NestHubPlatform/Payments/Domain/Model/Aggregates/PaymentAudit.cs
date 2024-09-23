using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace NestHubPlatform.Payments.Domain.Model.Aggregates;

public partial class PaymentAudit : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdateAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}