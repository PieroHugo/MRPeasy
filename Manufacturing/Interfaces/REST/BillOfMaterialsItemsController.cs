using Microsoft.AspNetCore.Mvc;
using MRPeasy.API.Manufacturing.Domain.Model.Commands;
using MRPeasy.API.Manufacturing.Domain.Services;
using MRPeasy.API.Manufacturing.Interfaces.Resources;
using MRPeasy.API.Manufacturing.Interfaces.Transform;

namespace MRPeasy.API.Manufacturing.Interfaces.REST;

/// <summary>
///     REST controller for bill of materials items.
/// </summary>
/// <author>Codex</author>
[ApiController]
[Route("api/v1/bill-of-materials/{billOfMaterialsId}/items")]
public class BillOfMaterialsItemsController : ControllerBase
{
    private readonly IBillOfMaterialsItemCommandService _commandService;

    public BillOfMaterialsItemsController(IBillOfMaterialsItemCommandService commandService)
    {
        _commandService = commandService;
    }

    /// <summary>
    ///     Creates a new bill of materials item.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<BillOfMaterialsItemResource>> PostAsync(int billOfMaterialsId, [FromBody] CreateBillOfMaterialsItemResource resource)
    {
        var command = CreateBillOfMaterialsItemCommandFromResourceAssembler.ToCommand(billOfMaterialsId, resource);
        var item = await _commandService.Handle(command);
        var result = BillOfMaterialsItemResourceFromEntityAssembler.ToResource(item);
        return Created(string.Empty, result);
    }
}
