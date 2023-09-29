using CrudApp.Core.Domain.Receipts.Models;

namespace CrudApp.Core.Domain.Receipts.Common;

public interface IReceiptRepository
{
    Task<Receipt> FindAsync(Guid id);

    Task AddAsync(Receipt receipt);

    Task DeleteAsync(Guid id);
}