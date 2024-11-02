using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace AquaEngine.API.Planning.Domain.Model.Aggregates;

public partial class OrderingMachineryAudit: IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]public DateTimeOffset? UpdatedDate { get; set; }
}