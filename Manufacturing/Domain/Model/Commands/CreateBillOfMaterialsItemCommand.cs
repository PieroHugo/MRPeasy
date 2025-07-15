namespace MRPeasy.API.Manufacturing.Domain.Model.Commands;

/// <summary>
///     Command to create a bill of materials item.
/// </summary>
public record CreateBillOfMaterialsItemCommand(
    int BillOfMaterialsId,
    Guid ItemProductNumber,
    int BatchId,
    int RequiredQuantity,
    DateTime ScheduledStartAt,
    DateTime RequiredAt);
