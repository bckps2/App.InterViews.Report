using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos.User;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class UserProfileMapperService : Profile
{
    public UserProfileMapperService()
    {
        CreateMap<UserDto, User>()
          .ForMember(c => c.UserCompanies, opt => opt.Ignore())
          .ReverseMap();
    }
}
