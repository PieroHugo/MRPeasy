using Microsoft.AspNetCore.Mvc;
using MRPeasy.API.Inventories.Domain.Model.Commands;
using MRPeasy.API.Inventories.Domain.Model.Queries;
using MRPeasy.API.Inventories.Domain.Services;
using MRPeasy.API.Inventories.Interfaces.Resources;
using MRPeasy.API.Inventories.Interfaces.Transform;

namespace MRPeasy.API.Inventories.Interfaces.REST;

/// <summary>
///     REST controller for products.
/// </summary>
/// <author>Codex</author>
[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductCommandService _commandService;
    private readonly IProductQueryService _queryService;

    public ProductsController(IProductCommandService commandService, IProductQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    /// <summary>
    ///     Creates a new product.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ProductResource>> PostAsync([FromBody] CreateProductResource resource)
    {
        var command = CreateProductCommandFromResourceAssembler.ToCommand(resource);
        var product = await _commandService.Handle(command);
        var result = ProductResourceFromEntityAssembler.ToResource(product);
        return CreatedAtAction(nameof(GetAsync), new { id = product.Id }, result);
    }

    /// <summary>
    ///     Gets a product by id.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResource>> GetAsync(int id)
    {
        var product = await _queryService.Handle(new GetProductByIdQuery(id));
        if (product == null) return NotFound();
        return ProductResourceFromEntityAssembler.ToResource(product);
    }
}
