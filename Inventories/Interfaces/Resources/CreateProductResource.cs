namespace MRPeasy.API.Inventories.Interfaces.Resources;

/// <summary>
///     Resource used to create a product.
/// </summary>
public class CreateProductResource
{
    public string Name { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public int MaxProductionCapacity { get; set; }
}
