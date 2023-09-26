using CrudApp.Core.Common;
using CrudApp.Persistence.CrudAppDb;

namespace CrudApp.Infrastructure.Core.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly CrudAppDbContext _context;

    public UnitOfWork(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}