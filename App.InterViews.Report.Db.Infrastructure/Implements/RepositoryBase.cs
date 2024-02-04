using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryBase<TEntry> : IRepositoryBase<TEntry> where TEntry : BaseEntity, new()
    {
        private readonly DbSet<TEntry> _set;
        private readonly DbDataContext _context;

        public RepositoryBase(DbDataContext context)
        {
            _context = context;
            _set = context.Set<TEntry>();
        }

        public async Task<Result<TEntry, ErrorResult>> GetByIdAsync(Guid id)
        {
            var result = await _set.FindAsync(id);

            if (result is null)
            {
                Log.Error($"On Get Object By Id {typeof(TEntry)}, Message Error : item Not found");
                return Result.Failure<TEntry, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            _context.Entry(result).State = EntityState.Detached;

            return Result.Success<TEntry, ErrorResult>(result); ;
        }

        public Result<IEnumerable<TEntry>, ErrorResult> GetAll()
        {
            var result = _set
                .AsNoTracking()
                .AsSplitQuery()
                .AsEnumerable();

            if (result is null || !result.Any())
            {
                Log.Error($"On Get All Objects {typeof(TEntry)}, Message Error : items Not found");
                return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<IEnumerable<TEntry>, ErrorResult>(result);
        }

        public Result<IEnumerable<TEntry>, ErrorResult> GetEntitiesByFilter(Expression<Func<TEntry, bool>> expression)
        {
            var result = _set.Where(expression);

            if (result is null || !result.Any())
            {
                Log.Error($"On Get {typeof(TEntry)} filter, Message Error : items Not found");
                return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<IEnumerable<TEntry>, ErrorResult>(result);
        }

        public Result<TEntry, ErrorResult> Update(TEntry item)
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

        public async Task<Result<TEntry, ErrorResult>> AddAsync(TEntry item)
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
                return Result.Failure<TEntry, ErrorResult>(ErrorResult.Exception<TEntry>(ex.Message));
            }
        }

        public Result<TEntry, ErrorResult> Delete(TEntry item)
        {
            try
            {
                var response = _set.Remove(item);
                _context.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On Delete Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                return Result.Failure<TEntry, ErrorResult>(ErrorResult.Exception<TEntry>(ex.Message));
            }
        }
    }
}
