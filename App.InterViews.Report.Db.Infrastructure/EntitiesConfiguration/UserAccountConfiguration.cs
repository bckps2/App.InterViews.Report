using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasOne(c => c.UserInfo)
               .WithOne(c => c.UserAccount)
               .HasForeignKey<UserInfo>(c => c.UserAccountId);
    }
}
