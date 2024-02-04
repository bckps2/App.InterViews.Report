using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IProcessReportService : IReportServiceBase<Process, ProcessDto>
{
    Result<IEnumerable<ProcessDto>, ErrorResult> GetProcessesByIdCompany(Guid idCompany);
}
