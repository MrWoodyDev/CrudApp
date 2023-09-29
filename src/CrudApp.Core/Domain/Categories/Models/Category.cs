using CrudApp.Core.Domain.Categories.Data;
using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Categories.Models;

public class Category
{
    private Category()
    {

    }

    public Category(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }

    public static async Task<Category> CreateAsync(string name)
    {
        var category = new Category(Guid.NewGuid(), name);
        return category;
    }

    public async Task UpdateAsync(UpdateCategoryData data)
    {
        Name = data.Name;
    }
}