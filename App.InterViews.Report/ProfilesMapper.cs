using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report;

public class ProfilesMapper : Profile
{
    public ProfilesMapper()
    {
        MapperProcess();
        MapperInterview();
        MapperCompany();
        MapperUser();
    }

    private void MapperInterview()
    {
        CreateMap<InterviewDto, InterviewModel>().ReverseMap();
    }

    private void MapperCompany()
    {
        CreateMap<CompanyDto, CompanyModel>()
            .ReverseMap();
    }

    private void MapperProcess()
    {
        CreateMap<ProcessDto, ProcessModel>().ReverseMap();
    }

    private void MapperUser()
    {
        CreateMap<UserDto, UserModel>().ReverseMap();
    }
}
