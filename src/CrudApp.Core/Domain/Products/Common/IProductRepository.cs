using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Products.Common;

public interface IProductRepository
{
    Task<Product> FindAsync(long id);

    Task<ICollection<Product>> FindByIdsAsync(ICollection<long> ids);

    Task AddAsync(Product product);

    Task DeleteAsync(long id);
}