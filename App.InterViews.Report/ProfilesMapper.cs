using App.InterViews.Report.Library.Entities;
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
        MapperUserCompany();
    }

    private void MapperInterview()
    {
        CreateMap<InterviewModel, InterView>().ReverseMap();
        CreateMap<InterviewDto, InterviewModel>().ReverseMap();

        CreateMap<InterviewDto, InterView>()
            .ForMember(interview => interview.InterViewersName, opt => opt.MapFrom(service => ListToToString(service)))
            .ReverseMap()
            .ForMember(service => service.NameInterViewers, opt => opt.MapFrom(interview => SplitNames(interview)))
            .ReverseMap();
    }

    private void MapperCompany()
    {
        CreateMap<CompanyModel, Company>().ReverseMap();

        CreateMap<CompanyDto, Company>()
            .ForMember(c => c.UserCompanies, opt => opt.MapFrom(d => new List<UserCompany> { new() {UserId = d.Users.FirstOrDefault()!.Id } }))
            .ReverseMap()
            .ForMember(c => c.Users, opt => opt.MapFrom(d => GetUsersFromUserCompanies(d.UserCompanies)));
            
        CreateMap<CompanyDto, CompanyModel>()
            .ReverseMap();
    }

    private void MapperProcess()
    {
        CreateMap<ProcessModel, Process>().ReverseMap();
        CreateMap<ProcessDto, Process>().ReverseMap();
        CreateMap<ProcessDto, ProcessModel>().ReverseMap();
    }

    private void MapperUser()
    {
        CreateMap<UserDto, User>()
            .ReverseMap()
            .ForMember(c => c.Companies, opt => opt.MapFrom(d => GetCompaniesFromUserCompanies(d.UserCompanies)));
    }

    private void MapperUserCompany()
    {
        CreateMap<UserCompanyDto, UserCompany>()
            .ReverseMap();
    }

    private static List<string>? SplitNames(InterView interView)
    {
        if (interView.InterViewersName?.Length > 0)
            return interView.InterViewersName.Split(',').ToList();
        return default;
    }

    private static string? ListToToString(InterviewDto serviceInterview)
    {
        if (serviceInterview.NameInterViewers != null && serviceInterview.NameInterViewers.Any())
            return string.Join(',', serviceInterview.NameInterViewers);
        return default;
    }

    private static ICollection<User> GetUsersFromUserCompanies(ICollection<UserCompany> userCompanies) 
    { 
        var users = new List<User>();

        foreach (var userCompany in userCompanies)
            users.Add(userCompany.User);

        return users;
    }

    private static ICollection<Company> GetCompaniesFromUserCompanies(ICollection<UserCompany> userCompanies)
    {
        var companies = new List<Company>();

        foreach (var userCompany in userCompanies)
            companies.Add(userCompany.Company);

        return companies;
    }
}
