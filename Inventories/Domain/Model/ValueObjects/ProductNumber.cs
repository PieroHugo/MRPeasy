namespace MRPeasy.API.Inventories.Domain.Model.ValueObjects;

/// <summary>
///     Business identifier for products.
/// </summary>
/// <param name="Value">Unique identifier</param>
public record ProductNumber(Guid Value)
{
    /// <summary>
    ///     Creates a new product number.
    /// </summary>
    /// <returns>New <see cref="ProductNumber"/> instance</returns>
    public static ProductNumber New() => new(Guid.NewGuid());
}
