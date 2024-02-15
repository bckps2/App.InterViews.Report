using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface ICompanyReportService : IBaseReportService<CompanyDto>
{
    Task<Result<IEnumerable<CompanyDto>, ErrorResult>> GetAllCompaniesByUser(Guid userId);
}
