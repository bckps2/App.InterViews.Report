using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class InterviewProfileMapperService : Profile
{
    public InterviewProfileMapperService()
    {
        CreateMap<InterviewDto, InterView>()
         .ForMember(c => c.InterviewInterviewers, opt => opt.MapFrom(d => GetInterviewInterviewers(d.Interviewers)))
         .ReverseMap()
         .ForMember(c => c.Interviewers, opt => opt.MapFrom(d => d.InterviewInterviewers.Select(f => f.Interviewer)));
    }

    private static ICollection<InterviewInterviewer> GetInterviewInterviewers(ICollection<InterviewerDto>? interviewers) 
    { 
        var interviewInterviewers = new List<InterviewInterviewer>();

        if (interviewers is null)
            return interviewInterviewers;

        foreach (var interviewer in interviewers) 
        {
            var interviewInterviewer = new InterviewInterviewer
            {
                Interviewer = new Interviewer
                {
                    CompanyId = interviewer.CompanyId,
                    Email = interviewer.Email,
                    JobPosition = interviewer.JobPosition,
                    Name = interviewer.Name,
                    Surnames = interviewer.Surnames,
                    Age = interviewer.Age
                }
            };

            interviewInterviewers.Add(interviewInterviewer);
        }

        return interviewInterviewers;
    }
}
