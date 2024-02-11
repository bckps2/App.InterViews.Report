using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {
        builder
            .HasKey(userCompany => new { userCompany.UserId, userCompany.CompanyId });

        builder
            .HasOne(userCompany => userCompany.Company)
            .WithMany(company => company.UserCompanies)
            .HasForeignKey(userCompany => userCompany.CompanyId);

        builder
            .HasOne(userCompany => userCompany.User)
            .WithMany(company => company.UserCompanies)
            .HasForeignKey(userCompany => userCompany.UserId);
    }
}
