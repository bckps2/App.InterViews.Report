using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class UserAccountProfileMapperService : Profile
{
    public UserAccountProfileMapperService()
    {
        CreateMap<UserAccountDto, UserAccount>().ReverseMap();
    }
}
