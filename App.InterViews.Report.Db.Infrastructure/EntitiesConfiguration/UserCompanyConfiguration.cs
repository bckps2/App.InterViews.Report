using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.InterViews.Report.Db.Infrastructure.EntitiesConfiguration;

public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {
        builder
            .HasKey(userCompany => new { userCompany.Id, userCompany.UserId, userCompany.CompanyId });

        builder
            .HasOne(userCompany => userCompany.Company)
            .WithMany(company => company.UserCompanies)
            .HasForeignKey(userCompany => userCompany.CompanyId);

        builder
            .HasOne(userCompany => userCompany.User)
            .WithMany(company => company.UserCompanies)
            .HasForeignKey(userCompany => userCompany.UserId);

        builder
            .Navigation(userCompany => userCompany.User)
            .AutoInclude();

        builder
            .Navigation(userCompany => userCompany.Company)
            .AutoInclude();
    }
}
