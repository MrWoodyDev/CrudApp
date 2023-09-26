using CrudApp.Core.Domain.Checks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApp.Persistence.CrudAppDb.EntityConfigurations;

public class CheckProductConfiguration : IEntityTypeConfiguration<CheckProducts>
{
    public void Configure(EntityTypeBuilder<CheckProducts> builder)
    {
        builder.HasKey(checkProduct => new { checkProduct.CheckId, checkProduct.ProductId });
    }
}