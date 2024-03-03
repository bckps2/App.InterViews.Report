using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class RepositoryBase<TEntry> : IRepositoryBase<TEntry> where TEntry : BaseEntity, new()
{
    protected readonly DbSet<TEntry> _set;
    protected readonly DbDataContext _context;

    public RepositoryBase(DbDataContext context)
    {
        _context = context;
        _set = context.Set<TEntry>();
    }

    public virtual async Task<Result<TEntry, ErrorResult>> GetByIdAsync(Guid id)
    {
        try
        {
            var result = await _set
                        .AsNoTracking()
                        .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            if (result is null)
            {
                Log.Error($"On Get Object By Id {typeof(TEntry)}, Message Error : item Not found");
                return Result.Failure<TEntry, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<TEntry, ErrorResult>(result);
        }
        catch (Exception ex)
        {
            Log.Error($"On update Object {typeof(TEntry)}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
            return Result.Failure<TEntry, ErrorResult>(ErrorResult.Exception<TEntry>(ex.Message));
        }
    }

    public virtual async Task<Result<IEnumerable<TEntry>, ErrorResult>> GetAllAsync()
    {
        try
        {
            var result = await _set
               .AsNoTracking()
               .AsSplitQuery()
               .ToListAsync();

            if (result is null || !result.Any())
            {
                Log.Error($"On Get All Objects {typeof(TEntry)}, Message Error : items Not found");
                return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<IEnumerable<TEntry>, ErrorResult>(result);
        }
        catch (Exception ex)
        {
            Log.Error($"On Add Object {typeof(TEntry)}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
            return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorResult.Exception<TEntry>($"{ex.Message}, {ex.InnerException?.Message}"));
        }
    }

    public virtual async Task<Result<IEnumerable<TEntry>, ErrorResult>> GetEntitiesByFilter(Expression<Func<TEntry, bool>> expression)
    {
        try
        {
            var result = await _set
                               .AsNoTracking()
                               .AsSplitQuery()
                               .Where(expression).ToListAsync();

            if (result is null || !result.Any())
            {
                Log.Error($"On Get {typeof(TEntry)} filter, Message Error : items Not found");
                return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<IEnumerable<TEntry>, ErrorResult>(result);
        }
        catch (Exception ex)
        {
            Log.Error($"On Add Object {typeof(TEntry)}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
            return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorResult.Exception<TEntry>($"{ex.Message}, {ex.InnerException?.Message}"));
        }
    }

    public virtual Result<TEntry, ErrorResult> Update(TEntry item)
    {
        try
        {
            var response = _set.Update(item);
            _context.SaveChanges();
            return Result.Success<TEntry, ErrorResult>(response.Entity);
        }
        catch (Exception ex)
        {
            Log.Error($"On update Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
            return Result.Failure<TEntry, ErrorResult>(ErrorResult.Exception<TEntry>(ex.Message));
        }
    }

    public virtual async Task<Result<TEntry, ErrorResult>> AddAsync(TEntry item)
    {
        try
        {
            item.DateCreated = DateTime.UtcNow;
            var response = await _set.AddAsync(item);
            await _context.SaveChangesAsync();
            return response.Entity;
        }
        catch (Exception ex)
        {
            Log.Error($"On Add Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
            return Result.Failure<TEntry, ErrorResult>(ErrorResult.Exception<TEntry>($"{ex.Message}, {ex.InnerException?.Message}"));
        }
    }

    public virtual async Task<Result<TEntry, ErrorResult>> DeleteAsync(Guid id)
    {
        try
        {
            var entityToRemove = await GetByIdAsyncAtached(id);

            if (entityToRemove.IsFailure)
                return entityToRemove.Error;

            var response = _set.Remove(entityToRemove.Value);
            await _context.SaveChangesAsync();
            return response.Entity;
        }
        catch (Exception ex)
        {
            Log.Error($"On Delete Object {typeof(TEntry)}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
            return Result.Failure<TEntry, ErrorResult>(ErrorResult.Exception<TEntry>(ex.Message));
        }
    }

    private async Task<Result<TEntry, ErrorResult>> GetByIdAsyncAtached(Guid id)
    {
        try
        {
            var result = await _set.FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            if (result is null)
            {
                Log.Error($"On Get Object By Id {typeof(TEntry)}, Message Error : item Not found");
                return Result.Failure<TEntry, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<TEntry, ErrorResult>(result); ;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
