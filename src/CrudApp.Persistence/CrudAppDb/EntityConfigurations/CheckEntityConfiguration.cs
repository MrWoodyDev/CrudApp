using CrudApp.Core.Domain.Checks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApp.Persistence.CrudAppDb.EntityConfigurations;

public class CheckEntityConfiguration : IEntityTypeConfiguration<Check>
{
    public void Configure(EntityTypeBuilder<Check> builder)
    {
        builder.HasKey(check => check.Id);
    }
}