using Microsoft.EntityFrameworkCore;
using MRPeasy.API.Manufacturing.Domain.Model.Aggregates;
using MRPeasy.API.Manufacturing.Domain.Repositories;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace MRPeasy.API.Manufacturing.Infrastructure.Repositories;

/// <summary>
///     Entity Framework Core implementation of <see cref="IBillOfMaterialsItemRepository"/>.
/// </summary>
public class BillOfMaterialsItemRepository(AppDbContext context)
    : BaseRepository<BillOfMaterialsItem>(context), IBillOfMaterialsItemRepository
{
    /// <inheritdoc />
    public async Task<BillOfMaterialsItem?> FindByCombinationAsync(Guid itemProductNumber, int batchId, int billOfMaterialsId)
    {
        return await context.Set<BillOfMaterialsItem>()
            .FirstOrDefaultAsync(b => b.ItemProductNumber.Value == itemProductNumber &&
                                     b.BatchId == batchId &&
                                     b.BillOfMaterialsId == billOfMaterialsId);
    }
}
