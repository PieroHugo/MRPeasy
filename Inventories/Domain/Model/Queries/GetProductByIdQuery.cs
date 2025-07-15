namespace MRPeasy.API.Inventories.Domain.Model.Queries;

/// <summary>
///     Query to obtain a product by identifier.
/// </summary>
/// <param name="Id">Product identifier</param>
public record GetProductByIdQuery(int Id);
