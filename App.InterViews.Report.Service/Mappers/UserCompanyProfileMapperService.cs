using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos.User;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class UserCompanyProfileMapperService : Profile
{
    public UserCompanyProfileMapperService()
    {
        CreateMap<UserCompanyDto, UserCompany>().ReverseMap();
    }
}
