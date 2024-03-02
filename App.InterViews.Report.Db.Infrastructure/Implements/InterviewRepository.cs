using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class InterviewRepository : RepositoryBase<InterView>, IInterviewRepository
{
    public InterviewRepository(DbDataContext context) : base(context)
    {
    }

    public override async Task<Result<IEnumerable<InterView>, ErrorResult>> GetAllAsync() 
    { 
        var results = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.InterviewInterviewers)
                            .ThenInclude(ii => ii.Interviewer)
                            .ToListAsync();

        if (results is null)
        {
            Log.Error($"On Get Object By Id {typeof(InterView)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<InterView>, ErrorResult>(ErrorResult.NotFound<InterView>());
        }

        return Result.Success<IEnumerable<InterView>, ErrorResult>(results);
    }    
    
    public async Task<Result<IEnumerable<InterView>, ErrorResult>> GetAllByIdProcessAsync(Guid processId)
    { 
        var results = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.InterviewInterviewers)
                            .ThenInclude(ii => ii.Interviewer)
                            .Where(interview => interview.IdProcess.Equals(processId))
                            .ToListAsync();

        if (results is null)
        {
            Log.Error($"On Get Object By Id {typeof(InterView)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<InterView>, ErrorResult>(ErrorResult.NotFound<InterView>());
        }

        return Result.Success<IEnumerable<InterView>, ErrorResult>(results);
    }
    
    public override async Task<Result<InterView, ErrorResult>> GetByIdAsync(Guid interviewId)
    {
        var results = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.InterviewInterviewers)
                            .ThenInclude(ii => ii.Interviewer)
                            .FirstOrDefaultAsync(interview => interview.Id.Equals(interviewId));

        if (results is null)
        {
            Log.Error($"On Get Object By Id {typeof(InterView)}, Message Error : items Not found");
            return Result.Failure<InterView, ErrorResult>(ErrorResult.NotFound<InterView>());
        }

        return Result.Success<InterView, ErrorResult>(results);
    }
}
