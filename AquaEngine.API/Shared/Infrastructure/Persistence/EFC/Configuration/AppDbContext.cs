using AquaEngine.API.Control.Domain.Model.Aggregates;

// using AquaEngine.API.boundedcontext.Domain.Model.Aggregates;


using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Control.Domain.Model.ValueObjects;

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
  
  builder.Entity<MonitoredMachine>()
       .ToTable("monitored_machines")
       .HasKey(mm => mm.Id);

    builder.Entity<Product>()
       .ToTable("Products")
       .HasKey(p => p.Id);

    builder.Entity<Product>()
       .Property(p => p.Id)
       .IsRequired()
       .ValueGeneratedOnAdd();

    builder.Entity<Product>()
       .Property(p => p.Name)
       .IsRequired();

    builder.Entity<Product>()
       .Property(p => p.QuantityPerUnit)
       .IsRequired();

    builder.Entity<Product>()
       .Property(p => p.UnitPrice)
       .IsRequired();

    builder.Entity<Product>()
       .Property(p => p.Quantity)
       .IsRequired();

    // Mapear solo UserId (int), no UserIdValue (ValueObject)
    builder.Entity<Product>()
       .Property(p => p.UserId)
       .HasColumnName("UserId")
       .IsRequired();

    // Ignorar la propiedad UserIdValue
    builder.Entity<Product>()
       .Ignore(p => p.UserIdValue);

    builder.UseSnakeCaseNamingConvention();

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
      
      // Planning Bounded Context
      builder.Entity<OrderingMachinery>().HasKey(o => o.Id);
      builder.Entity<OrderingMachinery>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<OrderingMachinery>().Property(o => o.Name).IsRequired().HasMaxLength(30);
      builder.Entity<OrderingMachinery>().Property(o => o.UrlToImage).IsRequired().HasMaxLength(250);
      builder.Entity<OrderingMachinery>().Property(o => o.Status).IsRequired().HasMaxLength(30);
    
      builder.UseSnakeCaseNamingConvention();
   }
}
