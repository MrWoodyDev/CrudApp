using CrudApp.Core.Domain.Categories.Data;
using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Categories.Models;

public class Category
{
    public Category(string name)
    {
        Name = name;
    }

    public long Id { get; set; }

    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }

    public static async Task<Category> CreateAsync(string name)
    {
        var category = new Category(name);
        return category;
    }

    public async Task UpdateAsync(UpdateCategoryData data)
    {
        Name = data.Name;
    }
}