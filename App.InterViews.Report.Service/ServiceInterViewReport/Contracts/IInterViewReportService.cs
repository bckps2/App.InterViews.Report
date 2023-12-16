using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IInterViewReportService<TEntry> : IReportServiceBase<TEntry, InterviewDto>
{
    Task<Result<InterviewDto, ErrorResult>> Update(InterviewDto dto);
}
