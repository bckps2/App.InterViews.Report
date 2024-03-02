using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class InterviewInterviewerConfiguration : IEntityTypeConfiguration<InterviewInterviewer>
{
    public void Configure(EntityTypeBuilder<InterviewInterviewer> builder)
    {
        builder
            .HasKey(x => new { x.InterviewId, x.InterviewerId });

        builder
            .HasOne(ii => ii.InterView)
            .WithMany(i => i.InterviewInterviewers)
            .HasForeignKey(i => i.InterviewId);

        builder
            .HasOne(ii => ii.Interviewer)
            .WithMany(i => i.InterviewInterviewers)
            .HasForeignKey(i => i.InterviewerId);
    }
}
