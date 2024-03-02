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

    public async Task<Result<IEnumerable<User>, ErrorResult>> GetAllByCompanyIdAsync(Guid companyId)
    {
        var result = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Where(c => c.Id.Equals(c.UserCompanies.FirstOrDefault(uc => uc.CompanyId == companyId).UserId))
                            .ToListAsync();

        if (result is null || !result.Any())
        {
            Log.Error($"On Get All Objects {typeof(User)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<User>, ErrorResult>(ErrorResult.NotFound<Company>());
        }

        return Result.Success<IEnumerable<User>, ErrorResult>(result);
    }

    public override async Task<Result<User, ErrorResult>> GetByIdAsync(Guid id)
    {
        var result = await _set
                            .AsNoTracking()
                            .Include(c => c.UserCompanies)
                            .ThenInclude(uc => uc.Company)
                            .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

        if (result is null)
        {
            Log.Error($"On Get Object By Id {typeof(User)}, Message Error : item Not found");
            return Result.Failure<User, ErrorResult>(ErrorResult.NotFound<User>());
        }

        return Result.Success<User, ErrorResult>(result); ;
    }

    public override async Task<Result<IEnumerable<User>, ErrorResult>> GetAllAsync()
    {
        var result = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.UserCompanies)
                            .ThenInclude(u => u.Company)
                            .Include(u => u.Role)
                            .ToListAsync();

        if (result is null || !result.Any())
        {
            Log.Error($"On Get All Objects {typeof(User)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<User>, ErrorResult>(ErrorResult.NotFound<User>());
        }

        return Result.Success<IEnumerable<User>, ErrorResult>(result);
    }
}
