using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class InterviewerProfileMapperService : Profile
{
    public InterviewerProfileMapperService()
    {
        CreateMap<InterviewerDto, Interviewer>()
         .ForMember(c => c.InterviewInterviewers, opt => opt.Ignore())
         .ReverseMap()
         .ForMember(c => c.Interviews, opt => opt.MapFrom(d => d.InterviewInterviewers.Select(f => f.InterView)));
    }
}
