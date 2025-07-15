using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Inventories.Domain.Model.Queries;
using MRPeasy.API.Inventories.Domain.Repositories;
using MRPeasy.API.Inventories.Domain.Services;

namespace MRPeasy.API.Inventories.Application.Internal.QueryServices;

/// <summary>
///     Application service to handle product queries.
/// </summary>
public class ProductQueryService(IProductRepository repository) : IProductQueryService
{
    private readonly IProductRepository _repository = repository;

    /// <inheritdoc />
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await _repository.FindByIdAsync(query.Id);
    }
}
