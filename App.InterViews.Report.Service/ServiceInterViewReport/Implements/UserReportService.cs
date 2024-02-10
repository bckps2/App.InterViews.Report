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
    public UserReportService(IRepositoryBase<User> iRepositoryBase, IMapper mapper) : base(iRepositoryBase, mapper)
    {
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
