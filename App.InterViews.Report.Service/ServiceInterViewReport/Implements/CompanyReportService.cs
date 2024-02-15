using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class CompanyReportService : BaseReportService<Company, CompanyDto>, ICompanyReportService
{
    private readonly IUserRepository _iuserRepository;
    private readonly ICompanyRepository _iCompanyRepository;

    public CompanyReportService(IUserRepository iuserRepository, ICompanyRepository iCompanyRepository, IMapper mapper): base(iCompanyRepository, mapper)
    {
        _iuserRepository = iuserRepository;
        _iCompanyRepository = iCompanyRepository;
    }

    public async Task<Result<IEnumerable<CompanyDto>, ErrorResult>> GetAllCompaniesByUser(Guid userId)
    {
        var results = await _iCompanyRepository.GetAllCompaniesByUserAsync(userId);

        return results.Map(val =>
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(val);
        });
    }

    public override async Task<Result<IEnumerable<CompanyDto>, ErrorResult>> GetAll()
    {
        var results = await _iCompanyRepository.GetAllAsync();

        return results.Map(val =>
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(val);
        });
    }

    public override async Task<Result<CompanyDto, ErrorResult>> Add(CompanyDto dto)
    {
        var company = _mapper.Map<Company>(dto);
        var user = await _iuserRepository.GetByIdAsync(dto.UserId ?? Guid.Empty);

        if (user.IsSuccess)
            company.UserCompanies.Add(new UserCompany { UserId = user.Value.Id });

        var result = await _iCompanyRepository.AddAsync(company);

        return result.Map(val =>
        {
            return _mapper.Map<CompanyDto>(val);
        });
    }
}
