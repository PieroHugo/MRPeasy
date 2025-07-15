namespace MRPeasy.API.Manufacturing.Domain.Model.ValueObjects;

/// <summary>
///     Reference to a product number within bill of materials items.
/// </summary>
/// <param name="Value">Identifier of the product</param>
public record ItemProductNumber(Guid Value);
