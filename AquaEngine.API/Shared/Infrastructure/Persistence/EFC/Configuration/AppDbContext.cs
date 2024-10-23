using AquaEngine.API.Analytics.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Aggregates;
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
