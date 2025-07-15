using MRPeasy.API.Manufacturing.Domain.Model.Commands;
using MRPeasy.API.Manufacturing.Interfaces.Resources;

namespace MRPeasy.API.Manufacturing.Interfaces.Transform;

/// <summary>
///     Converts <see cref="CreateBillOfMaterialsItemResource"/> to <see cref="CreateBillOfMaterialsItemCommand"/>.
/// </summary>
public static class CreateBillOfMaterialsItemCommandFromResourceAssembler
{
    public static CreateBillOfMaterialsItemCommand ToCommand(int billOfMaterialsId, CreateBillOfMaterialsItemResource resource)
    {
        return new CreateBillOfMaterialsItemCommand(
            billOfMaterialsId,
            resource.ItemProductNumber,
            resource.BatchId,
            resource.RequiredQuantity,
            resource.ScheduledStartAt,
            resource.RequiredAt);
    }
}
