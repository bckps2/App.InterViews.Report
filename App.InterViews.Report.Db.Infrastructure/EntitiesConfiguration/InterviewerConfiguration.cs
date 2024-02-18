using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class InterviewerConfiguration : IEntityTypeConfiguration<Interviewer>
{
    public void Configure(EntityTypeBuilder<Interviewer> builder)
    {
        builder
            .HasOne(interviewer => interviewer.Company)
            .WithMany(company => company.Interviewers)
            .HasForeignKey(interviewer => interviewer.CompanyId);
    }
}
