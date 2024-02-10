using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class CompanyReportService : ICompanyReportService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<User> _irepositoryUser;
    private readonly IRepositoryBase<Company> _iRepositoryBase;

    public CompanyReportService(IRepositoryBase<Company> iRepositoryBase, IRepositoryBase<User> irepositoryUser, IMapper mapper)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
        _irepositoryUser = irepositoryUser;
    }

    public async Task<Result<CompanyDto, ErrorResult>> GetById(Guid id)
    {
        var value = await _iRepositoryBase.GetByIdAsync(id);

        return value.Map(val =>
        {
            return _mapper.Map<CompanyDto>(val);
        });
    }

    public Result<IEnumerable<CompanyDto>, ErrorResult> GetAll()
    {
        var companies = _iRepositoryBase.GetAll();

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(value);
        });
    }

    public async Task<Result<CompanyDto, ErrorResult>> Add(CompanyDto dto)
    {
        var company = _mapper.Map<Company>(dto);
        var user = await _irepositoryUser.GetByIdAsync(dto.UserId);

        if (user.IsSuccess)
            company.UserCompanies.Add(new UserCompany { UserId = user.Value.Id });

        var result = await _iRepositoryBase.AddAsync(company);

        return result.Map(val =>
        {
            return _mapper.Map<CompanyDto>(val);
        });
    }

    public async Task<Result<CompanyDto, ErrorResult>> Delete(Guid id)
    {
        var response = await _iRepositoryBase.DeleteAsync(id);

        return response.Map(val =>
        {
            return _mapper.Map<CompanyDto>(val);
        });
    }
}
