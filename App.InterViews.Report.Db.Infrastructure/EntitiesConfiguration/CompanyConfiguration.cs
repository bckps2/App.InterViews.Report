using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .Navigation(e => e.Process)
            .AutoInclude();

        builder
            .Navigation(e => e.UserCompanies)
            .AutoInclude();

        builder
            .HasMany(c => c.Process)
            .WithOne(c => c.Company);

        builder
          .HasIndex(c => new { c.CompanyName })
          .IsUnique();
    }
}
