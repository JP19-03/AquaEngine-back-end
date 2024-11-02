using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaEngine.API.Analytics.Domain.Model.Aggregate;


public partial class Maintenance: IEntityWithCreatedUpdatedDate
{
    
    [Column("CreatedAt")]public DateTimeOffset? CreatedDate { get; set; }  
    [Column("UpdatedAt")]public DateTimeOffset? UpdatedDate { get; set; }

}