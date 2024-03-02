using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class ProcessConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder
            .HasMany(p => p.Interviews)
            .WithOne(i => i.Process);

        builder
            .HasOne(p => p.Company)
            .WithMany(c => c.Process)
            .HasForeignKey(p => p.CompanyId);

        builder
           .Navigation(e => e.Interviews)
           .AutoInclude();
    }
}
