using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos.Interview;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class InterViewReportService : BaseReportService<InterView, InterviewDto>, IInterViewReportService
{
    private readonly IInterviewRepository _interviewRepository;

    public InterViewReportService(IMapper mapper,IInterviewRepository interviewRepository) : base(interviewRepository, mapper)
    {
        _interviewRepository = interviewRepository;
    }

    #region GETS
    new public async Task<Result<IEnumerable<InterviewDto>, ErrorResult>> GetAllAsync()
    {
        var results = await _iRepository.GetAllAsync();

        return results.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewDto>>(value);
        });
    }

    new public async Task<Result<InterviewInterviewerDto, ErrorResult>> GetByIdAsync(Guid interviewId)
    {
        var interviews = await _iRepository.GetByIdAsync(interviewId);

        return interviews.Map(value =>
        {
            return _mapper.Map<InterviewInterviewerDto>(value);
        });
    }

    public async Task<Result<IEnumerable<InterviewInterviewerDto>, ErrorResult>> GetAllByProcessIdAsync(Guid idProcess)
    {
        var interviews = await _interviewRepository.GetAllByIdProcessAsync(idProcess);

        return interviews.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewInterviewerDto>>(value);
        });
    }
    #endregion

    #region Modify Entities
    public override async Task<Result<InterviewDto, ErrorResult>> AddAsync(InterviewDto interviewDto)
    {
        var interview = _mapper.Map<InterView>(interviewDto);
        var interviewEntity = await _iRepository.AddAsync(interview);

        if (interviewEntity.IsFailure)
            return interviewEntity.Error;

        return interviewEntity.Map(value =>
        {
            return _mapper.Map<InterviewDto>(value);
        });
    }
    #endregion
}
