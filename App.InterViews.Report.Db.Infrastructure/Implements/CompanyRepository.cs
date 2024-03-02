using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(DbDataContext context) : base(context)
    {
    }

    public async Task<Result<IEnumerable<Company>, ErrorResult>> GetAllByUserIdAsync(Guid userId)
    {
        var result = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Where(c => c.Id.Equals(c.UserCompanies.FirstOrDefault(uc => uc.UserId == userId).CompanyId))
                            .ToListAsync();

        if (result is null || !result.Any())
        {
            Log.Error($"On Get All Objects {typeof(Company)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<Company>, ErrorResult>(ErrorResult.NotFound<Company>());
        }

        return Result.Success<IEnumerable<Company>, ErrorResult>(result);
    }

    public override async Task<Result<IEnumerable<Company>, ErrorResult>> GetAllAsync()
    {
        var result = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.UserCompanies)
                            .ThenInclude(uc => uc.User)
                            .ToListAsync();

        if (result is null || !result.Any())
        {
            Log.Error($"On Get All Objects {typeof(Company)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<Company>, ErrorResult>(ErrorResult.NotFound<Company>());
        }

        return Result.Success<IEnumerable<Company>, ErrorResult>(result);
    }

    public override async Task<Result<Company, ErrorResult>> GetByIdAsync(Guid id)
    {
        var result = await _set
                            .AsNoTracking()
                            .Include (c => c.UserCompanies)
                            .ThenInclude(uc => uc.User)
                            .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

        if (result is null)
        {
            Log.Error($"On Get Object By Id {typeof(Company)}, Message Error : item Not found");
            return Result.Failure<Company, ErrorResult>(ErrorResult.NotFound<Company>());
        }

        return Result.Success<Company, ErrorResult>(result);
    }
}
