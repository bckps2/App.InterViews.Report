using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;
using AutoMapper;

namespace App.InterViews.Report.Impl.Service.Mapper
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<ServiceInterviewModel, InterView>().ReverseMap();
            CreateMap<ServiceInformationModel, InformationInterView>().ReverseMap();
        }
    }
}
