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
    private readonly IRepositoryBase<Interviewer> _interviewerRepository;
    private readonly IRepositoryBase<InterviewInterviewer> _interviewInterviewerRepository;

    public InterViewReportService(IMapper mapper,
        IRepositoryBase<Interviewer> interviewerRepository,
        IInterviewRepository interviewRepository,
        IRepositoryBase<InterviewInterviewer> interviewInterviewerRepository
        ) : base(interviewRepository, mapper)
    {
        _interviewerRepository = interviewerRepository;
        _interviewInterviewerRepository = interviewInterviewerRepository;
    }

    public override async Task<Result<InterviewDto, ErrorResult>> Add(InterviewDto interviewDto)
    {
        var (interviewers, interviewInterviewers) = await GetInterviewersAsync(interviewDto);

        interviewDto.Interviewers = interviewers;
        
        var interview = _mapper.Map<InterView>(interviewDto);
        var interviewEntity = await _iRepository.AddAsync(interview);

        if (interviewEntity.IsFailure)
            return interviewEntity.Error;

        await SaveInterviewInterviewersAsync(interviewInterviewers, interviewEntity.Value.Id);

        return interviewEntity.Map(value =>
        {
            return _mapper.Map<InterviewDto>(value);
        });
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

    private async Task<(List<InterviewerDto>, List<InterviewInterviewer>)> GetInterviewersAsync(InterviewDto interviewDto) 
    {
        var interviewers = new List<InterviewerDto>();
        var interviewInterviewers = new List<InterviewInterviewer>();

        if (interviewDto.Interviewers != null && interviewDto.Interviewers.Any()) 
        {
            foreach (var interviewer in interviewDto.Interviewers)
            {
                var interviewerEntity = await _interviewerRepository
                     .GetEntitiesByFilter(c => c.Email.Equals(interviewer.Email));

                if (interviewerEntity.IsFailure)
                    interviewers.Add(interviewer);
                else
                    interviewInterviewers.Add(new InterviewInterviewer { Interviewer = interviewerEntity.Value.FirstOrDefault()! });
            }
        }

        return (interviewers, interviewInterviewers);
    }

    private async Task SaveInterviewInterviewersAsync(List<InterviewInterviewer> interviewInterviewers, Guid interviewId) 
    {
        foreach (var item in interviewInterviewers)
        {
            item.InterviewId = interviewId;
            await _interviewInterviewerRepository.AddAsync(item);
        }
    }
}
