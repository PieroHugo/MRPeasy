namespace MRPeasy.API.Inventories.Domain.Model.Commands;

/// <summary>
///     Command to create a product.
/// </summary>
/// <param name="Name">Product name</param>
/// <param name="ProductType">Product type acronym</param>
/// <param name="MaxProductionCapacity">Maximum production capacity</param>
public record CreateProductCommand(string Name, string ProductType, int MaxProductionCapacity);
