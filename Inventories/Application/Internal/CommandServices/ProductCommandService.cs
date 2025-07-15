using MRPeasy.API.Domain.Repositories;
using MRPeasy.API.Inventories.Domain.Model.Aggregates;
using MRPeasy.API.Inventories.Domain.Model.Commands;
using MRPeasy.API.Inventories.Domain.Repositories;
using MRPeasy.API.Inventories.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace MRPeasy.API.Inventories.Application.Internal.CommandServices;

/// <summary>
///     Application service to handle product commands.
/// </summary>
public class ProductCommandService(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IConfiguration configuration) : IProductCommandService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IConfiguration _configuration = configuration;

    /// <inheritdoc />
    public async Task<Product> Handle(CreateProductCommand command)
    {
        var type = command.ProductType switch
        {
            "BTP" => EProductType.BuildToPrint,
            "BTS" => EProductType.BuildToSpecification,
            "MTS" => EProductType.MadeToStock,
            "MTO" => EProductType.MadeToOrder,
            "MTA" => EProductType.MadeToAssemble,
            _ => throw new ArgumentException("Invalid product type")
        };

        if (await _productRepository.FindByNameAsync(command.Name) is not null)
            throw new InvalidOperationException("Product name already exists.");

        var minCap = _configuration.GetValue<int>("CapacityThresholds:minCapacityThreshold");
        var maxCap = _configuration.GetValue<int>("CapacityThresholds:maxCapacityThreshold");
        if (command.MaxProductionCapacity < minCap || command.MaxProductionCapacity > maxCap)
            throw new InvalidOperationException("Invalid max production capacity.");

        var product = new Product(command.Name, type, command.MaxProductionCapacity);

        await _productRepository.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return product;
    }
}
