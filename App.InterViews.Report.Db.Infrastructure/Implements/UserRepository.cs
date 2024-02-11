using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class UserRepository : RepositoryBase<User>, IUserRepository
{

    public UserRepository(DbDataContext context) : base(context)
    {
    }

    public override async Task<Result<IEnumerable<User>, ErrorResult>> GetAllAsync()
    {
        var result = await _context.Users
                                .Include(c => c.UserCompanies)
                                .ThenInclude(u => u.Company)
                                .ToListAsync();

        if (result is null || !result.Any())
        {
            Log.Error($"On Get All Objects {typeof(User)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<User>, ErrorResult>(ErrorResult.NotFound<User>());
        }

        return Result.Success<IEnumerable<User>, ErrorResult>(result);
    }
}
