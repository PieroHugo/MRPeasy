using MRPeasy.API.Inventories.Domain.Model.Commands;
using MRPeasy.API.Inventories.Interfaces.Resources;

namespace MRPeasy.API.Inventories.Interfaces.Transform;

/// <summary>
///     Converts <see cref="CreateProductResource"/> to <see cref="CreateProductCommand"/>.
/// </summary>
public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommand(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Name, resource.ProductType, resource.MaxProductionCapacity);
    }
}
