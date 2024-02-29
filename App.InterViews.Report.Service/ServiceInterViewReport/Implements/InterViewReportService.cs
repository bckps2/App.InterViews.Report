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

    public async Task<Result<IEnumerable<InterviewDto>, ErrorResult>> GetAllInterviewsAsync() 
    {
        var results = await _iRepository.GetAllAsync();

        return results.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewDto>>(value);
        });
    }

    public override async Task<Result<InterviewDto, ErrorResult>> Add(InterviewDto interviewDto)
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

    public async Task<Result<IEnumerable<InterviewInterviewerDto>, ErrorResult>> GetAllByIdProcess(Guid idProcess)
    {
        var interviews = await _interviewRepository.GetAllByIdProcessAsync(idProcess);
        
        return interviews.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewInterviewerDto>>(value);
        });
    }
    
    public async Task<Result<InterviewInterviewerDto, ErrorResult>> GetInterviewByIdAsync(Guid interviewId)
    {
        var interviews = await _interviewRepository.GetByIdAsync(interviewId);
        
        return interviews.Map(value =>
        {
            return _mapper.Map<InterviewInterviewerDto>(value);
        });
    }
}
