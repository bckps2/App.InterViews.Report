using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IProcessReportService : IBaseReportService<ProcessDto>
{
    Task<Result<IEnumerable<ProcessDto>, ErrorResult>> GetAllByCompanyIdAsync(Guid idCompany);
}
