namespace MRPeasy.API.Manufacturing.Interfaces.Resources;

/// <summary>
///     Resource to create a bill of materials item.
/// </summary>
public class CreateBillOfMaterialsItemResource
{
    public Guid ItemProductNumber { get; set; }
    public int BatchId { get; set; }
    public int RequiredQuantity { get; set; }
    public DateTime ScheduledStartAt { get; set; }
    public DateTime RequiredAt { get; set; }
}
