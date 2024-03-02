using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos.Company;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface ICompanyReportService : IBaseReportService<CompanyDto>
{
    new Task<Result<IEnumerable<CompanyUserDto>, ErrorResult>> GetAllAsync();
    new Task<Result<CompanyUserDto, ErrorResult>> GetByIdAsync(Guid companyId);
    Task<Result<IEnumerable<CompanyDto>, ErrorResult>> GetAllByUserId(Guid userId);
}
