using CrudApp.Core.Domain.Checks.Common;
using CrudApp.Core.Domain.Checks.Models;
using CrudApp.Persistence.CrudAppDb;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Checks;

public class CheckRepository : ICheckRepository
{
    private readonly CrudAppDbContext _context;

    public CheckRepository(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<Check> FindAsync(long id)
    {
        var check = await _context.Checks.SingleOrDefaultAsync(check => check.Id == id);
        return check ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Check check)
    {
        await _context.AddAsync(check);
    }

    public async Task DeleteAsync(long id)
    {
        var checkToBeRemove = await _context.Checks.SingleOrDefaultAsync(check => check.Id == id);
        if (checkToBeRemove is null) throw new InvalidOperationException();
        _context.Checks.Remove(checkToBeRemove);
    }
}