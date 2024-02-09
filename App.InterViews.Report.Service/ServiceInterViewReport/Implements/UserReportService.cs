using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class UserReportService : IUserReportService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<User> _iRepositoryBase;

    public UserReportService(IRepositoryBase<User> iRepositoryBase, IMapper mapper)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
    }

    public Task<Result<UserDto, ErrorResult>> Add(UserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto, ErrorResult>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Result<IEnumerable<UserDto>, ErrorResult> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<UserDto, ErrorResult>> GetById(Guid id)
    {
        var value = await _iRepositoryBase.GetByIdAsync(id);

        return value.Map(val =>
        {
            return _mapper.Map<UserDto>(val);
        });
    }
}
