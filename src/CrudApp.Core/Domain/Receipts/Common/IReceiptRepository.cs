using CrudApp.Core.Domain.Receipts.Models;

namespace CrudApp.Core.Domain.Receipts.Common;

public interface IReceiptRepository
{
    Task<Receipt> FindAsync(long id);

    Task AddAsync(Receipt receipt);

    Task DeleteAsync(long id);
}