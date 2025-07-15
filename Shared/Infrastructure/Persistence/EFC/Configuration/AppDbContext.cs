using MRPeasy.API.Infrastructure.Persistence.EFC.Configuration.Extensions;
//using Mitsui.Sale.Infrastructure.Persistence.EFC.Configurations;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Apply configurations for the Sale bounded context
        //builder.ApplySaleConfiguration();

        // Use snake case naming convention for the database
        builder.UseSnakeCaseNamingConvention();
    }
    // Método para crear la base de datos y aplicar migraciones
    public void EnsureDatabaseCreatedOrMigrated()
    {
        this.Database.Migrate();
    }
}