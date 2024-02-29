using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos.Interview;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IInterViewReportService : IBaseReportService<InterviewDto>
{
    Task<Result<IEnumerable<InterviewDto>, ErrorResult>> GetAllInterviewsAsync();
    Task<Result<InterviewInterviewerDto, ErrorResult>> GetInterviewByIdAsync(Guid interviewId);
    Task<Result<IEnumerable<InterviewInterviewerDto>, ErrorResult>> GetAllByIdProcess(Guid idProcess);
}
