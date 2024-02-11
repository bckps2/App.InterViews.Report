using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IInterViewReportService : IBaseReportService<InterviewDto>
{
    Task<Result<InterviewDto, ErrorResult>> Update(InterviewDto dto);
    Task<Result<IEnumerable<InterviewDto>, ErrorResult>> GetAllByIdProcess(Guid idProcess);
}
