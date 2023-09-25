using CrudApp.Core.Domain.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApp.Persistence.CrudAppDb.EntityConfigurations;

public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(productCategory => new { productCategory.ProductId, productCategory.CategoryId });
    }
}