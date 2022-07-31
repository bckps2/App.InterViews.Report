using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Models;
using AutoMapper;

namespace App.InterViews.Report
{
    public class ProfilesMapper : Profile
    {
        public ProfilesMapper() 
        {
            CreateMap<InterviewModel, ServiceInterviewModel>().ReverseMap();
            CreateMap<InformationInterviewModel, ServiceInformationModel>().ReverseMap();
            CreateMap<CompanyModel, ServiceCompanyModel>().ReverseMap();
        }
    }
}
