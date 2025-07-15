using Microsoft.EntityFrameworkCore;
using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Inventories.Domain.Repositories;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace MRPeasy.API.Inventories.Infrastructure.Repositories;

/// <summary>
///     Entity Framework Core implementation of <see cref="IProductRepository"/>.
/// </summary>
public class ProductRepository(AppDbContext context)
    : BaseRepository<Product>(context), IProductRepository
{
    /// <inheritdoc />
    public async Task<Product?> FindByNameAsync(string name)
    {
        return await context.Set<Product>().FirstOrDefaultAsync(p => p.Name == name);
    }

    /// <inheritdoc />
    public async Task<Product?> FindByProductNumberAsync(Guid productNumber)
    {
        return await context.Set<Product>()
            .FirstOrDefaultAsync(p => p.ProductNumber.Value == productNumber);
    }
}
