using CrudApp.Core.Domain.Products.Common;
using CrudApp.Core.Domain.Products.Models;
using CrudApp.Persistence.CrudAppDb;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Products.Common;

public class ProductRepository : IProductRepository
{
    private readonly CrudAppDbContext _context;

    public ProductRepository(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> FindAsync(long id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        return product ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
    }

    public async Task DeleteAsync(long id)
    {
        var productToBeRemove = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (productToBeRemove is null) throw new InvalidOperationException(); 
        _context.Products.Remove(productToBeRemove);
    }
}