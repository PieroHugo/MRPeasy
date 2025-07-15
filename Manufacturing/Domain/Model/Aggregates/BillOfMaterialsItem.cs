using MRPeasy.API.Manufacturing.Domain.Model.ValueObjects;

namespace MRPeasy.API.Manufacturing.Domain.Model.Aggregates;

/// <summary>
///     Bill of materials item aggregate root.
/// </summary>
/// <author>Codex</author>
public class BillOfMaterialsItem
{
    public int Id { get; private set; }
    public int BillOfMaterialsId { get; private set; }
    public ItemProductNumber ItemProductNumber { get; private set; } = null!;
    public int BatchId { get; private set; }
    public int RequiredQuantity { get; private set; }
    public DateTime ScheduledStartAt { get; private set; }
    public DateTime RequiredAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private BillOfMaterialsItem() { }

    public BillOfMaterialsItem(int billOfMaterialsId, ItemProductNumber itemProductNumber,
        int batchId, int requiredQuantity, DateTime scheduledStartAt, DateTime requiredAt)
    {
        BillOfMaterialsId = billOfMaterialsId;
        ItemProductNumber = itemProductNumber;
        BatchId = batchId;
        RequiredQuantity = requiredQuantity;
        ScheduledStartAt = scheduledStartAt;
        RequiredAt = requiredAt;
    }
}
