using CrudApp.Core.Domain.Categories.Common;
using CrudApp.Core.Domain.Categories.Models;
using CrudApp.Persistence.CrudAppDb;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Categories.Common;

public class CategoryRepository : ICategoryRepository
{
    private readonly CrudAppDbContext _context;

    public CategoryRepository(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<Category> FindAsync(long id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(category => category.Id == id);
        return category ?? throw new InvalidOperationException();
    }

    public async Task<ICollection<Category>> FindByIdsAsync(ICollection<long> ids)
    {
        var categories = await _context.Categories.Where(c => ids.Contains(c.Id)).ToListAsync();
        return categories;
    }

    public async Task AddAsync(Category category)
    {
        await _context.AddAsync(category);
    }

    public async Task DeleteAsync(long id)
    {
        var categoryToBeRemove = await _context.Categories.FirstOrDefaultAsync(category => category.Id == id);
        if (categoryToBeRemove is null) throw new InvalidOperationException();
        _context.Categories.Remove(categoryToBeRemove);
    }
}