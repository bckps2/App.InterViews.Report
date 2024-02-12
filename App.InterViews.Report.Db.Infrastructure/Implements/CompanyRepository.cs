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

    public async Task<Result<IEnumerable<Company>, ErrorResult>> GetAllCompaniesByUserAsync(Guid userId)
    {
        var result = await _context.Companies
                                .AsNoTracking()
                                .AsSplitQuery()
                                .Where(c => c.Id.Equals(c.UserCompanies.FirstOrDefault(uc => uc.UserId == userId).CompanyId))
                                .Include(c => c.UserCompanies)
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
        var result = await _context.Companies
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
}
