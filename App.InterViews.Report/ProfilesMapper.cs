using App.InterViews.Report.Models;
using App.InterViews.Report.Models.Interview;
using App.InterViews.Report.Models.Interviewer;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.Dtos.Company;
using App.InterViews.Report.Service.Dtos.Interview;
using App.InterViews.Report.Service.Dtos.Interviewer;
using App.InterViews.Report.Service.Dtos.User;
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
        MapperInterviewer();
        MapperUserAccount();
        MapperRole();
    }

    private void MapperInterview()
    {
        CreateMap<InterviewDto, InterviewModel>().ReverseMap();
        CreateMap<InterviewDto, InterviewUpdateModel>().ReverseMap();
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

    private void MapperInterviewer()
    {
        CreateMap<InterviewerModel, InterviewerDto>().ReverseMap();
        CreateMap<InterviewerUpdateModel, InterviewerDto>().ReverseMap();
    }

    private void MapperUserAccount()
    {
        CreateMap<UserAccountModel, UserAccountDto>().ReverseMap();
    } 
    
    private void MapperRole()
    {
        CreateMap<RoleModel, RoleDto>().ReverseMap();
    }
}
