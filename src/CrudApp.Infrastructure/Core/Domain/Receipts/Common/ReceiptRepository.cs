using CrudApp.Core.Domain.Receipts.Common;
using CrudApp.Core.Domain.Receipts.Models;
using CrudApp.Persistence.CrudAppDb;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Receipts.Common;

public class ReceiptRepository : IReceiptRepository
{
    private readonly CrudAppDbContext _context;

    public ReceiptRepository(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<Receipt> FindAsync(long id)
    {
        var receipt = await _context.Receipts.Include(p => p.Products).SingleOrDefaultAsync(receipt => receipt.Id == id);
        return receipt ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Receipt receipt)
    {
        await _context.AddAsync(receipt);
    }

    public async Task DeleteAsync(long id)
    {
        var receiptToBeRemove = await _context.Receipts.SingleOrDefaultAsync(check => check.Id == id);
        if (receiptToBeRemove is null) throw new InvalidOperationException();
        _context.Receipts.Remove(receiptToBeRemove);
    }
}