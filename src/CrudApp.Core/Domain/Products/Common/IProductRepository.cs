using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Products.Common;

public interface IProductRepository
{
    Task<Product> FindAsync(Guid id);

    Task<ICollection<Product>> FindByIdsAsync(ICollection<Guid> ids);

    Task AddAsync(Product product);

    Task DeleteAsync(Guid id);
}