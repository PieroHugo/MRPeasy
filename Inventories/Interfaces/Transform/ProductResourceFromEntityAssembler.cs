using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Inventories.Interfaces.Resources;

namespace MRPeasy.API.Inventories.Interfaces.Transform;

/// <summary>
///     Converts <see cref="Product"/> to <see cref="ProductResource"/>.
/// </summary>
public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResource(Product entity)
    {
        return new ProductResource
        {
            Id = entity.Id,
            ProductNumber = entity.ProductNumber.Value,
            Name = entity.Name,
            ProductType = entity.ProductType.ToString(),
            CurrentProductionQuantity = entity.CurrentProductionQuantity,
            MaxProductionCapacity = entity.MaxProductionCapacity
        };
    }
}
