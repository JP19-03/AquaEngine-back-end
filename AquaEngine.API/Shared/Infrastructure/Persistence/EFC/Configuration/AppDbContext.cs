using AquaEngine.API.Control.Domain.Model.Aggregates;

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
      // ANALYTICS
      // Monitoring
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

      // Cambiar la forma de mapear UserId
      builder.Entity<Product>()
         .Property(p => p.UserId) // Acceder al valor del ValueObject
         .HasColumnName("UserId") // Nombre de columna
         .IsRequired();

      builder.UseSnakeCaseNamingConvention();
   }

}

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
