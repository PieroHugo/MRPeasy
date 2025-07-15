namespace MRPeasy.API.Manufacturing.Interfaces.Resources;

/// <summary>
///     Resource representing a bill of materials item.
/// </summary>
public class BillOfMaterialsItemResource
{
    public int Id { get; set; }
    public int BillOfMaterialsId { get; set; }
    public Guid ItemProductNumber { get; set; }
    public int BatchId { get; set; }
    public int RequiredQuantity { get; set; }
    public DateTime ScheduledStartAt { get; set; }
    public DateTime RequiredAt { get; set; }
}
