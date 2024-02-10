using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class CompanyProfileMapper : Profile
{
    public CompanyProfileMapper()
    {
        CreateMap<CompanyDto, Company>()
        .ForMember(c => c.UserCompanies, opt => opt.Ignore())
        .ReverseMap()
        .ForMember(c => c.Users, opt => opt.MapFrom(d => d.UserCompanies.Select(company => company.User)));
    }
}
