using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Models;
using AutoMapper;

namespace App.InterViews.Report
{
    public class ProfilesMapper : Profile
    {
        public ProfilesMapper()
        {
            MapperProcess();
            MapperInterview();
            MapperCompany();
        }

        private void MapperInterview()
        {
            CreateMap<InterviewModel, InterView>().ReverseMap();
            CreateMap<ServiceInterviewDto, InterviewModel>().ReverseMap();

            CreateMap<ServiceInterviewDto, InterView>()
                .ForMember(interview => interview.InterViewersName, opt => opt.MapFrom(service => ListToToString(service)))
                .ReverseMap()
                .ForMember(service => service.NameInterViewers, opt => opt.MapFrom(interview => SplitNames(interview)));
        }

        private void MapperCompany()
        {
            CreateMap<CompanyModel, Company>().ReverseMap();
            CreateMap<ServiceCompanyDto, Company>().ReverseMap();
            CreateMap<ServiceCompanyDto, CompanyModel>().ReverseMap();
        }

        private void MapperProcess()
        {
            CreateMap<ProcessModel, Process>().ReverseMap();
            CreateMap<ServiceProcessDto, Process>().ReverseMap();
            CreateMap<ServiceProcessDto, ProcessModel>().ReverseMap();
        }

        private static List<string>? SplitNames(InterView interView)
        {
            if (interView.InterViewersName?.Length > 0)
                return interView.InterViewersName.Split(',').ToList();
            return default;
        }

        private static string? ListToToString(ServiceInterviewDto serviceInterview)
        {
            if (serviceInterview.NameInterViewers != null && serviceInterview.NameInterViewers.Any())
                return string.Join(',', serviceInterview.NameInterViewers);
            return default;
        }
    }
}
