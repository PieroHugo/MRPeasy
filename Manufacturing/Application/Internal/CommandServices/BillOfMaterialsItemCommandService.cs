using MRPeasy.API.Domain.Repositories;
using MRPeasy.API.Inventories.Domain.Repositories;
using MRPeasy.API.Manufacturing.Domain.Model.Aggregates;
using MRPeasy.API.Manufacturing.Domain.Model.Commands;
using MRPeasy.API.Manufacturing.Domain.Model.ValueObjects;
using MRPeasy.API.Manufacturing.Domain.Repositories;
using MRPeasy.API.Manufacturing.Domain.Services;

namespace MRPeasy.API.Manufacturing.Application.Internal.CommandServices;

/// <summary>
///     Application service to handle bill of materials item commands.
/// </summary>
public class BillOfMaterialsItemCommandService(
    IBillOfMaterialsItemRepository repository,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IBillOfMaterialsItemCommandService
{
    private readonly IBillOfMaterialsItemRepository _repository = repository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    /// <inheritdoc />
    public async Task<BillOfMaterialsItem> Handle(CreateBillOfMaterialsItemCommand command)
    {
        if (command.RequiredAt > DateTime.UtcNow)
            throw new InvalidOperationException("requiredAt cannot be in the future.");
        if (command.ScheduledStartAt < command.RequiredAt.AddDays(30))
            throw new InvalidOperationException("scheduledStartAt must be at least 30 days after requiredAt.");

        if (await _repository.FindByCombinationAsync(command.ItemProductNumber, command.BatchId, command.BillOfMaterialsId) != null)
            throw new InvalidOperationException("Combination already exists.");

        var product = await _productRepository.FindByProductNumberAsync(command.ItemProductNumber)
                      ?? throw new InvalidOperationException("Product does not exist.");

        if (product.CurrentProductionQuantity + command.RequiredQuantity > product.MaxProductionCapacity)
            throw new InvalidOperationException("Exceeds product capacity.");

        product.IncreaseProduction(command.RequiredQuantity);

        var item = new BillOfMaterialsItem(command.BillOfMaterialsId,
            new ItemProductNumber(command.ItemProductNumber),
            command.BatchId,
            command.RequiredQuantity,
            command.ScheduledStartAt,
            command.RequiredAt);

        await _repository.AddAsync(item);
        _productRepository.Update(product);
        await _unitOfWork.CompleteAsync();
        return item;
    }
}
