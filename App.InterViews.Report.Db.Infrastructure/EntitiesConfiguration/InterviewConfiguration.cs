using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration
{
    public class InterviewConfiguration : IEntityTypeConfiguration<InterView>
    {
        public void Configure(EntityTypeBuilder<InterView> builder)
        {
            builder
                .HasOne(interview => interview.Process)
                .WithMany(process => process.Interviews)
                .HasForeignKey(interview => interview.IdProcess);

            builder
                .Property(interview => interview.TypeInterView)
                .HasColumnType("nvarchar(20)");
        }
    }
}
