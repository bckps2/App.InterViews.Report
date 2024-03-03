using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
       
    }
}
