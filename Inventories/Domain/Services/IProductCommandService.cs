using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Inventories.Domain.Model.Commands;

namespace MRPeasy.API.Inventories.Domain.Services;

/// <summary>
///     Service to handle product commands.
/// </summary>
public interface IProductCommandService
{
    /// <summary>
    ///     Creates a new product.
    /// </summary>
    /// <param name="command">Command data</param>
    /// <returns>The created product</returns>
    Task<Product> Handle(CreateProductCommand command);
}
