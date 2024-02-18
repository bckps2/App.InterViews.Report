using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos.Company;
using App.InterViews.Report.Service.Dtos.User;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class CompanyProfileMapperService : Profile
{
    public CompanyProfileMapperService()
    {
        CreateMap<CompanyUserDto, Company>()
        .ForMember(c => c.UserCompanies, opt => opt.Ignore())
        .ReverseMap()
        .ForMember(c => c.Users, opt => opt.MapFrom(d => d.UserCompanies.Select(f => f.User)));

        CreateMap<CompanyDto, Company>()
       .ReverseMap();
    }
}
