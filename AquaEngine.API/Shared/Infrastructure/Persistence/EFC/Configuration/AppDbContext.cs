// using AquaEngine.API.boundedcontext.Domain.Model.Aggregates;

using AquaEngine.API.Planning.Domain.Model.Aggregates;
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

      /*
       //Usa esto de ejemplo
       
      builder.Entity<MonitoredMachinery>().ToTable("Monitoring");
      builder.Entity<MonitoredMachinery>().HasKey(f => f.Id);
      builder.Entity<MonitoredMachinery>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<MonitoredMachinery>().Property(f => f.Name).IsRequired();
      builder.Entity<MonitoredMachinery>().Property(f => f.UrlToImage).IsRequired();
      builder.Entity<MonitoredMachinery>().Property(f => f.Status).IsRequired(); 
    
      
      */
      
      // Planning Bounded Context
      builder.Entity<OrderingMachinery>().HasKey(o => o.Id);
      builder.Entity<OrderingMachinery>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<OrderingMachinery>().Property(o => o.Name).IsRequired().HasMaxLength(30);
      builder.Entity<OrderingMachinery>().Property(o => o.urlToImage).IsRequired().HasMaxLength(250);
      builder.Entity<OrderingMachinery>().Property(o => o.Status).IsRequired().HasMaxLength(30);
    
      builder.UseSnakeCaseNamingConvention();
   }
}
