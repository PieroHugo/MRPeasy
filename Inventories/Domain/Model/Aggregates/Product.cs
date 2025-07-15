using MRPeasy.API.Inventories.Domain.Model.ValueObjects;

namespace MRPeasy.API.Inventories.Domain.Model.Aggregates;

/// <summary>
///     Enumerates supported product types.
/// </summary>
public enum EProductType
{
    BuildToPrint = 0,
    BuildToSpecification = 1,
    MadeToStock = 2,
    MadeToOrder = 3,
    MadeToAssemble = 4
}

/// <summary>
///     Product aggregate root.
/// </summary>
/// <author>Codex</author>
public class Product
{
    public int Id { get; private set; }
    public ProductNumber ProductNumber { get; private set; } = ProductNumber.New();
    public string Name { get; private set; } = null!;
    public EProductType ProductType { get; private set; }
    public int CurrentProductionQuantity { get; private set; }
    public int MaxProductionCapacity { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Product() { }

    public Product(string name, EProductType productType, int maxProductionCapacity)
    {
        Name = name;
        ProductType = productType;
        MaxProductionCapacity = maxProductionCapacity;
        CurrentProductionQuantity = 0;
    }

    public void IncreaseProduction(int quantity)
    {
        if (CurrentProductionQuantity + quantity > MaxProductionCapacity)
        {
            throw new InvalidOperationException("Exceeds max production capacity.");
        }
        CurrentProductionQuantity += quantity;
    }
}
