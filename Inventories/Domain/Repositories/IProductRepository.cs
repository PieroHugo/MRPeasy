using MRPeasy.API.Domain.Repositories;
using MRPeasy.API.Inventories.Domain.Model.Aggregates;

namespace MRPeasy.API.Inventories.Domain.Repositories;

/// <summary>
///     Repository for products.
/// </summary>
public interface IProductRepository : IBaseRepository<Product>
{
    /// <summary>
    ///     Finds a product by name.
    /// </summary>
    Task<Product?> FindByNameAsync(string name);

    /// <summary>
    ///     Finds a product by product number.
    /// </summary>
    Task<Product?> FindByProductNumberAsync(Guid productNumber);
}
