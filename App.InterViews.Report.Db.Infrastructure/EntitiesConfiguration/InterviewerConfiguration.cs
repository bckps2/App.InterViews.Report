using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class InterviewerConfiguration : IEntityTypeConfiguration<Interviewer>
{
    public void Configure(EntityTypeBuilder<Interviewer> builder)
    {
        builder
            .HasOne(c => c.InterView)
            .WithMany(u => u.Interviewers)
            .HasForeignKey(c => c.InterviewId);
    }
}
