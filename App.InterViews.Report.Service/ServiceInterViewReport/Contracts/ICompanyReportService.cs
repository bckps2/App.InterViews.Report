using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos.Company;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface ICompanyReportService : IBaseReportService<CompanyDto>
{
    Task<Result<IEnumerable<CompanyUserDto>, ErrorResult>> GetAllCompanies();
    Task<Result<CompanyUserDto, ErrorResult>> GetCompanyByIdAsync(Guid companyId);
    Task<Result<IEnumerable<CompanyDto>, ErrorResult>> GetAllCompaniesByUser(Guid userId);
}
