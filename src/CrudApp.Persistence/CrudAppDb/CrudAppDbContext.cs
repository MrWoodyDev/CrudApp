using CrudApp.Core.Domain.Categories.Models;
using CrudApp.Core.Domain.Checks.Models;
using CrudApp.Core.Domain.Products.Models;
using CrudApp.Persistence.CrudAppDb.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Persistence.CrudAppDb;

public class CrudAppDbContext : DbContext
{
    public CrudAppDbContext(DbContextOptions<CrudAppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ProductCategory> ProductsCategories { get; set; }

    public DbSet<Check> Checks { get; set; }

    public DbSet<CheckProducts> CheckProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CheckEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CheckProductConfiguration());
    }
}