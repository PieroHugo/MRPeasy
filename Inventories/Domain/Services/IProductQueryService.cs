using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Inventories.Domain.Model.Queries;

namespace MRPeasy.API.Inventories.Domain.Services;

/// <summary>
///     Service to handle product queries.
/// </summary>
public interface IProductQueryService
{
    /// <summary>
    ///     Gets a product by identifier.
    /// </summary>
    /// <param name="query">Query data</param>
    /// <returns>Product or null</returns>
    Task<Product?> Handle(GetProductByIdQuery query);
}
