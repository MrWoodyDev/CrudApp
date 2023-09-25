using CrudApp.Core.Domain.Categories.Models;

namespace CrudApp.Core.Domain.Products.Models;

public class ProductCategory
{
    private ProductCategory()
    {
        
    }

    public ProductCategory(Product product, Category category)
    {
        Product = product;
        Category = category;
    }

    public long ProductId { get; set; }

    public Product Product { get; set; }

    public long CategoryId { get; set; }

    public Category Category { get; set; }
}