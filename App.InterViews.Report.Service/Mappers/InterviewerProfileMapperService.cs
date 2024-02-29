using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos.Interviewer;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class InterviewerProfileMapperService : Profile
{
    public InterviewerProfileMapperService()
    {
        CreateMap<InterviewerDto, Interviewer>()
         .ForMember(c => c.InterviewInterviewers, opt => opt.Ignore())
         .ReverseMap();
        
        CreateMap<InterviewerInterviewDto, Interviewer>()
         .ForMember(c => c.InterviewInterviewers, opt => opt.MapFrom(c => GetInterviewInterviewers(c.InterviewsId)))
         .ReverseMap()
         .ForMember(c => c.InterviewsId, opt => opt.MapFrom(d => d.InterviewInterviewers.Select(f => f.InterviewId)));
    }

    private static ICollection<InterviewInterviewer> GetInterviewInterviewers(ICollection<Guid> interviewsId) 
    {
        var interviewInterviewers = new HashSet<InterviewInterviewer>();

        if(interviewsId is null)
            return interviewInterviewers;

        foreach (var interviewId in interviewsId)
        {
            var interviewInterviewer = new InterviewInterviewer { InterviewId = interviewId };
            interviewInterviewers.Add(interviewInterviewer);
        }
       
        return interviewInterviewers;
    }
}
