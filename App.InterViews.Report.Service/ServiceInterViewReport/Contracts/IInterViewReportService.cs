using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos.Interview;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IInterViewReportService : IBaseReportService<InterviewDto>
{
    new Task<Result<IEnumerable<InterviewDto>, ErrorResult>> GetAllAsync();
    new Task<Result<InterviewInterviewerDto, ErrorResult>> GetByIdAsync(Guid interviewId);
    Task<Result<IEnumerable<InterviewInterviewerDto>, ErrorResult>> GetAllByProcessIdAsync(Guid idProcess);
}
