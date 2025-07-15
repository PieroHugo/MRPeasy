using MRPeasy.API.Domain.Repositories;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}