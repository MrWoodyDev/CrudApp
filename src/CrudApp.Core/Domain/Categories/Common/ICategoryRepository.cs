using CrudApp.Core.Domain.Categories.Models;

namespace CrudApp.Core.Domain.Categories.Common;

public interface ICategoryRepository
{
    Task<Category> FindAsync(long id);

    Task AddAsync(Category category);

    Task DeleteAsync(long id);
}