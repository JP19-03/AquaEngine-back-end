// using AquaEngine.API.boundedcontext.Domain.Model.Aggregates;
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
    
      builder.UseSnakeCaseNamingConvention();
   }
}
