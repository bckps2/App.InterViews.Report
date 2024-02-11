using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class UserReportService : BaseReportService<User, UserDto>, IUserReportService
{
    private readonly ICompanyRepository _iCompanyRepository;

    public UserReportService(ICompanyRepository iCompanyRepository, IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
        _iCompanyRepository = iCompanyRepository;
    }

    public override async Task<Result<IEnumerable<UserDto>, ErrorResult>> GetAll()
    {
        var results = await _iRepository.GetAllAsync();

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

    public async Task<Result<List<UserDto>, ErrorResult>> GetByIds(ICollection<Guid> ids)
    {
        var users = new List<UserDto>();

        foreach (var id in ids)
        {
            var user = await GetById(id);
            if (user.IsSuccess)
                users.Add(user.Value);
        }

        return users;
    }
}
