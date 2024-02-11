using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class InterViewReportService : BaseReportService<InterView, InterviewDto>, IInterViewReportService
{
    public InterViewReportService(IMapper mapper, IInterviewRepository interviewRepository) : base(interviewRepository, mapper)
    {
    }

    public async Task<Result<IEnumerable<InterviewDto>, ErrorResult>> GetAllByIdProcess(Guid idProcess)
    {
        var interviews = await _iRepository.GetEntitiesByFilter(interview => interview.IdProcess == idProcess);

        if (interviews.IsFailure)
            return interviews.Error;

        return interviews.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewDto>>(value);
        });
    }
}
