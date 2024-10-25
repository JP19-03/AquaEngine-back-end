// using AquaEngine.API.boundedcontext.Domain.Model.Aggregates;

using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);

      //Monitoring
      builder.Entity<MonitoredMachine>()
         .ToTable("Monitoring")
         .HasKey(mm => mm.Id);

      builder.Entity<MonitoredMachine>()
         .Property(mm => mm.Id)
         .IsRequired()
         .ValueGeneratedOnAdd();

      builder.Entity<MonitoredMachine>()
         .Property(mm=>mm.Name)
         .IsRequired();
    
      builder.Entity<MonitoredMachine>()
         .Property(mm=>mm.Status)
         .IsRequired();
      builder.Entity<MonitoredMachine>()
         .Property(mm=>mm.UrlToImage)
         .IsRequired();
      builder.Entity<MonitoredMachine>()
         .Property(mm=>mm.UserId)
         .HasColumnName("UserId")
         .IsRequired();
      
      builder.UseSnakeCaseNamingConvention();
   }
}
