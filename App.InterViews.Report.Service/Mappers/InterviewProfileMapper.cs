using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class InterviewProfileMapper : Profile
{
    public InterviewProfileMapper()
    {
        CreateMap<InterviewDto, InterView>()
         .ForMember(interview => interview.InterViewersName, opt => opt.MapFrom(service => ListToToString(service)))
         .ReverseMap()
         .ForMember(service => service.NameInterViewers, opt => opt.MapFrom(interview => SplitNames(interview)))
         .ReverseMap();
    }

    private static List<string>? SplitNames(InterView interView)
    {
        if (interView.InterViewersName?.Length > 0)
            return interView.InterViewersName.Split(',').ToList();
        return default;
    }

    private static string? ListToToString(InterviewDto serviceInterview)
    {
        if (serviceInterview.NameInterViewers != null && serviceInterview.NameInterViewers.Any())
            return string.Join(',', serviceInterview.NameInterViewers);
        return default;
    }
}
