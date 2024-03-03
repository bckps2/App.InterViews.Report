using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class UserRepository : RepositoryBase<UserInfo>, IUserRepository
{

    public UserRepository(DbDataContext context) : base(context)
    {
    }

    public override async Task<Result<IEnumerable<UserInfo>, ErrorResult>> GetAllAsync()
    {
        var result = await _context.UsersInfo
                                .AsNoTracking()
                                .AsSplitQuery()
                                .Include(c => c.UserCompanies)
                                .ThenInclude(u => u.Company)
                                .ToListAsync();

        if (result is null || !result.Any())
        {
            Log.Error($"On Get All Objects {typeof(UserInfo)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<UserInfo>, ErrorResult>(ErrorResult.NotFound<UserInfo>());
        }

        return Result.Success<IEnumerable<UserInfo>, ErrorResult>(result);
    }
}
