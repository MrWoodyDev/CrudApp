using CrudApp.Core.Domain.Checks.Models;

namespace CrudApp.Core.Domain.Checks.Common;

public interface ICheckRepository
{
    Task<Check> FindAsync(long id);

    Task AddAsync(Check check);

    Task DeleteAsync(long id);
}