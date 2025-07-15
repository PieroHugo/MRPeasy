using MRPeasy.API.Domain.Repositories;
using MRPeasy.API.Manufacturing.Domain.Model.Aggregates;

namespace MRPeasy.API.Manufacturing.Domain.Repositories;

/// <summary>
///     Repository for bill of materials items.
/// </summary>
public interface IBillOfMaterialsItemRepository : IBaseRepository<BillOfMaterialsItem>
{
    /// <summary>
    ///     Finds an item by unique combination.
    /// </summary>
    Task<BillOfMaterialsItem?> FindByCombinationAsync(Guid itemProductNumber, int batchId, int billOfMaterialsId);
}
