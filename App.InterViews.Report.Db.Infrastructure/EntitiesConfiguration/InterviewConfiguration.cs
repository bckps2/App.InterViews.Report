using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder
            .HasOne(interview => interview.Process)
            .WithMany(process => process.Interviews)
            .HasForeignKey(interview => interview.ProcessId);

        builder
            .Property(interview => interview.TypeInterView)
            .HasColumnType("nvarchar(20)");
    }
}
