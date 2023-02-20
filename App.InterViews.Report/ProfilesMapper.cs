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
            CreateMap<CompanyModel, Company>().ReverseMap();
            CreateMap<ServiceCompanyDto, Company>().ReverseMap();
            CreateMap<ServiceCompanyDto, CompanyModel>().ReverseMap();

            CreateMap<InterviewModel, InterView>().ReverseMap();

            CreateMap<ProcessModel, Process>().ReverseMap();
            CreateMap<ServiceProcessDto, Process>().ReverseMap();
            CreateMap<ServiceProcessDto, ProcessModel>().ReverseMap();
        }
    }
}
