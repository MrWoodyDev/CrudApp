using CrudApp.Core.Domain.Categories.Models;

namespace CrudApp.Core.Domain.Categories.Common;

public interface ICategoryRepository
{
    Task<Category> FindAsync(Guid id);

    Task<ICollection<Category>> FindByIdsAsync(ICollection<Guid> ids);

    Task AddAsync(Category category);

    Task DeleteAsync(Guid id);
}