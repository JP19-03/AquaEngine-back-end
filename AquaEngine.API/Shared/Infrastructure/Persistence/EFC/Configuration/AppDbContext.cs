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
      // ANALYTICS
      // Monitoring
      builder.Entity<MonitoredMachine>()
         .ToTable("monitored_machines")
         .HasKey(mm => mm.Id);

      builder.Entity<MonitoredMachine>()
         .Property(mm => mm.Id)
         .IsRequired()
         .ValueGeneratedOnAdd();

      builder.Entity<MonitoredMachine>()
         .Property(mm => mm.Name)
         .IsRequired();
    
      builder.Entity<MonitoredMachine>()
         .Property(mm => mm.Status)
         .IsRequired();
      builder.Entity<MonitoredMachine>()
         .Property(mm => mm.UrlToImage)
         .IsRequired();
      builder.Entity<MonitoredMachine>()
         .Property(mm => mm.UserId)
         .HasColumnName("UserId")
         .IsRequired();
      
      // Maintenance
      builder.Entity<Maintenance>()
         .ToTable("maintenances")
         .HasKey(ma => ma.Id);
      builder.Entity<Maintenance>()
         .Property(ma => ma.Id)
         .IsRequired()
         .ValueGeneratedOnAdd();
      builder.Entity<Maintenance>()
         .Property(ma => ma.TechnicianName)
         .IsRequired();
      builder.Entity<Maintenance>()
         .Property(ma => ma.IssueType)
         .IsRequired();
      builder.Entity<Maintenance>()
         .Property(ma => ma.Description)
         .IsRequired();
      builder.Entity<Maintenance>()
         .Property(ma => ma.AdditionalInfo)
         .IsRequired();
      builder.Entity<Maintenance>()
         .Property(ma => ma.MonitoredMachineId)
         .IsRequired();
      
      builder.UseSnakeCaseNamingConvention();
   }
}