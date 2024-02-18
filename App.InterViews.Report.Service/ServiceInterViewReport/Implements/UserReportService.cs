using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos.User;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class UserReportService : BaseReportService<User, UserDto>, IUserReportService
{
    private readonly IUserRepository _iUserRepository;
    private readonly ICompanyRepository _iCompanyRepository;

    public UserReportService(ICompanyRepository iCompanyRepository, IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
        _iUserRepository = userRepository;
        _iCompanyRepository = iCompanyRepository;
    }

    public async Task<Result<IEnumerable<UserCompanyDto>, ErrorResult>> GetAllUsers()
    {
        var results = await _iUserRepository.GetAllAsync();

        return results.Map(val =>
        {
            return _mapper.Map<IEnumerable<UserCompanyDto>>(val);
        });
    }
    
    public async Task<Result<IEnumerable<UserDto>, ErrorResult>> GetUsersByCompanyIdAsync(Guid companyId)
    {
        var results = await _iUserRepository.GetUsersByCompanyIdAsync(companyId);

        return results.Map(val =>
        {
            return _mapper.Map<IEnumerable<UserDto>>(val);
        });
    }

    public override async Task<Result<UserDto, ErrorResult>> Add(UserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var company = await _iCompanyRepository.GetByIdAsync(dto.CompanyId ?? Guid.Empty);

        if (company.IsSuccess)
            user.UserCompanies.Add(new UserCompany { CompanyId = company.Value.Id });

        var result = await _iRepository.AddAsync(user);

        return result.Map(val =>
        {
            return _mapper.Map<UserDto>(val);
        });
    }

    public async Task<Result<UserCompanyDto, ErrorResult>> GetUserByIdAsync(Guid userId)
    {
        var result = await _iRepository.GetByIdAsync(userId);

        return result.Map(val =>
        {
            return _mapper.Map<UserCompanyDto>(val);
        });
    }
}
