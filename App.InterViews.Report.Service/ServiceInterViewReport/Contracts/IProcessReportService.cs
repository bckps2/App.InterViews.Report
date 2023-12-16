using CSharpFunctionalExtensions;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.CrossCutting.Helper;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IProcessReportService<TEntry> : IReportServiceBase<TEntry, ProcessDto>
{
    Result<IEnumerable<ProcessDto>, ErrorResult> GetProcessesByIdCompany(int idCompany);
}
