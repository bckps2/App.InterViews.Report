using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class RoleProfileMapperService : Profile
{
    public RoleProfileMapperService()
    {
        CreateMap<RoleDto, Role>()
            .ReverseMap();
    }
}
