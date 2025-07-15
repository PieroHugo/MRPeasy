using MRPeasy.API.Infrastructure.Persistence.EFC.Configuration.Extensions;
using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Manufacturing.Domain.Model.Aggregates;
//using Mitsui.Sale.Infrastructure.Persistence.EFC.Configurations;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<BillOfMaterialsItem> BillOfMaterialsItems => Set<BillOfMaterialsItem>();
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>(entity =>
        {
            entity.ToTable("products");
            entity.HasKey(p => p.Id);

            entity.OwnsOne(p => p.ProductNumber, pn =>
            {
                pn.Property(pn => pn.Value).HasColumnName("product_number");
            });

            entity.Property(p => p.Name).IsRequired().HasMaxLength(60);
            entity.HasIndex(p => p.Name).IsUnique();

            entity.Property(p => p.ProductType).IsRequired();
            entity.Property(p => p.CurrentProductionQuantity).IsRequired();
            entity.Property(p => p.MaxProductionCapacity).IsRequired();
        });

        builder.Entity<BillOfMaterialsItem>(entity =>
        {
            entity.ToTable("bill_of_materials_items");
            entity.HasKey(b => b.Id);

            entity.OwnsOne(b => b.ItemProductNumber, pn =>
            {
                pn.Property(p => p.Value).HasColumnName("item_product_number");
            });

            entity.Property(b => b.BillOfMaterialsId).IsRequired();
            entity.Property(b => b.BatchId).IsRequired();
            entity.Property(b => b.RequiredQuantity).IsRequired();
            entity.Property(b => b.ScheduledStartAt).IsRequired();
            entity.Property(b => b.RequiredAt).IsRequired();

            entity.HasIndex(b => new { b.BillOfMaterialsId, b.BatchId, b.ItemProductNumber }).IsUnique();
        });

        // Use snake case naming convention for the database
        builder.UseSnakeCaseNamingConvention();
    }
    // Método para crear la base de datos y aplicar migraciones
    public void EnsureDatabaseCreatedOrMigrated()
    {
        this.Database.Migrate();
    }
}
