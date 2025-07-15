namespace MRPeasy.API.Inventories.Interfaces.Resources;

/// <summary>
///     Resource representing a product.
/// </summary>
public class ProductResource
{
    public int Id { get; set; }
    public Guid ProductNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public int CurrentProductionQuantity { get; set; }
    public int MaxProductionCapacity { get; set; }
}
