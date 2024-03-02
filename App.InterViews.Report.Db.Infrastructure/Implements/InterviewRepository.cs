using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class InterviewRepository : RepositoryBase<Interview>, IInterviewRepository
{
    public InterviewRepository(DbDataContext context) : base(context)
    {
    }

    public override async Task<Result<IEnumerable<Interview>, ErrorResult>> GetAllAsync() 
    { 
        var results = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.InterviewInterviewers)
                            .ThenInclude(ii => ii.Interviewer)
                            .ToListAsync();

        if (results is null)
        {
            Log.Error($"On Get Object By Id {typeof(Interview)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<Interview>, ErrorResult>(ErrorResult.NotFound<Interview>());
        }

        return Result.Success<IEnumerable<Interview>, ErrorResult>(results);
    }    
    
    public async Task<Result<IEnumerable<Interview>, ErrorResult>> GetAllByIdProcessAsync(Guid processId)
    { 
        var results = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.InterviewInterviewers)
                            .ThenInclude(ii => ii.Interviewer)
                            .Where(interview => interview.ProcessId.Equals(processId))
                            .ToListAsync();

        if (results is null)
        {
            Log.Error($"On Get Object By Id {typeof(Interview)}, Message Error : items Not found");
            return Result.Failure<IEnumerable<Interview>, ErrorResult>(ErrorResult.NotFound<Interview>());
        }

        return Result.Success<IEnumerable<Interview>, ErrorResult>(results);
    }
    
    public override async Task<Result<Interview, ErrorResult>> GetByIdAsync(Guid interviewId)
    {
        var results = await _set
                            .AsNoTracking()
                            .AsSplitQuery()
                            .Include(c => c.InterviewInterviewers)
                            .ThenInclude(ii => ii.Interviewer)
                            .FirstOrDefaultAsync(interview => interview.Id.Equals(interviewId));

        if (results is null)
        {
            Log.Error($"On Get Object By Id {typeof(Interview)}, Message Error : items Not found");
            return Result.Failure<Interview, ErrorResult>(ErrorResult.NotFound<Interview>());
        }

        return Result.Success<Interview, ErrorResult>(results);
    }
}
