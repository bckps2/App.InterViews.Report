using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class InterviewProfileMapperService : Profile
{
    public InterviewProfileMapperService()
    {
        CreateMap<InterviewDto, InterView>()
         .ForMember(c => c.InterviewInterviewers, opt => opt.Ignore())
         .ReverseMap()
         .ForMember(c => c.Interviewers, opt => opt.MapFrom(d => d.InterviewInterviewers.Select(f => f.Interviewer)));
    }
}
