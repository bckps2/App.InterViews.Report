using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Models;
using AutoMapper;

namespace App.InterViews.Report
{
    public class ProfilesMapper : Profile
    {
        public ProfilesMapper() 
        {
            CreateMap<InterviewModel, InterView>().ReverseMap();
            CreateMap<InformationInterViewModel, InformationInterView>().ReverseMap();
            CreateMap<CompanyModel, Company>().ReverseMap();
        }
    }
}
