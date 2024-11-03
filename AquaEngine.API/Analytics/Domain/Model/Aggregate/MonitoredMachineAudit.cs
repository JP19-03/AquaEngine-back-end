using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;

public partial class MonitoredMachine: IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]public DateTimeOffset? CreatedDate { get; set; }  
    [Column("UpdatedAt")]public DateTimeOffset? UpdatedDate { get; set; }
    
}