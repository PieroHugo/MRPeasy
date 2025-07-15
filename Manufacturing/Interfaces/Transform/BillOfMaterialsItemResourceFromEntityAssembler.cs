using MRPeasy.API.Manufacturing.Domain.Model.Aggregates;
using MRPeasy.API.Manufacturing.Interfaces.Resources;

namespace MRPeasy.API.Manufacturing.Interfaces.Transform;

/// <summary>
///     Converts <see cref="BillOfMaterialsItem"/> to <see cref="BillOfMaterialsItemResource"/>.
/// </summary>
public static class BillOfMaterialsItemResourceFromEntityAssembler
{
    public static BillOfMaterialsItemResource ToResource(BillOfMaterialsItem entity)
    {
        return new BillOfMaterialsItemResource
        {
            Id = entity.Id,
            BillOfMaterialsId = entity.BillOfMaterialsId,
            ItemProductNumber = entity.ItemProductNumber.Value,
            BatchId = entity.BatchId,
            RequiredQuantity = entity.RequiredQuantity,
            ScheduledStartAt = entity.ScheduledStartAt,
            RequiredAt = entity.RequiredAt
        };
    }
}
