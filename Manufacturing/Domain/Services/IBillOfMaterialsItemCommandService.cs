using MRPeasy.API.Manufacturing.Domain.Model.Aggregates;
using MRPeasy.API.Manufacturing.Domain.Model.Commands;

namespace MRPeasy.API.Manufacturing.Domain.Services;

/// <summary>
///     Service to handle bill of materials item commands.
/// </summary>
public interface IBillOfMaterialsItemCommandService
{
    /// <summary>
    ///     Creates a new bill of materials item.
    /// </summary>
    /// <param name="command">Command data</param>
    /// <returns>The created item</returns>
    Task<BillOfMaterialsItem> Handle(CreateBillOfMaterialsItemCommand command);
}
