using CSharpFunctionalExtensions;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IProcessReportService : IReportServiceBase<Process, ProcessDto>
{
    Result<IEnumerable<ProcessDto>, ErrorResult> GetProcessesByIdCompany(int idCompany);
}
