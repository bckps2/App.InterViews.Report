using Serilog;
using FluentValidation;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.CrossCutting.Helper.ErrorResults;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryBase<TEntry> : IRepositoryBase<TEntry> where TEntry : class, new()
    {
        private readonly DbSet<TEntry> _set;
        private readonly DbDataContext _context;
        private readonly IValidator<TEntry> _iValidator;

        public RepositoryBase(DbDataContext context, IValidator<TEntry> iValidator)
        {
            _context = context;
            _set = context.Set<TEntry>();
            _iValidator = iValidator;
        }

        public async Task<Result<TEntry, ErrorResult>> GetByIdAsync(int id)
        {
            var result = await _set.FindAsync(id);

            if (result is null)
            {
                Log.Error($"On Get Object By Id {nameof(TEntry).GetType()}, Message Error : item Not found");
                return Result.Failure<TEntry, ErrorResult>(ErrorNotFound.NotFound<TEntry>());
            }

            return result;
        }

        public Result<IEnumerable<TEntry>, ErrorResult> GetAll()
        {
            var result = _set.AsEnumerable();

            if (result is null || !result.Any()) 
            {
                Log.Error($"On Get All Objects {nameof(TEntry).GetType()}, Message Error : items Not found");
                return Result.Failure<IEnumerable<TEntry>, ErrorResult>(ErrorNotFound.NotFound<TEntry>());
            }

            return Result.Success<IEnumerable<TEntry>, ErrorResult>(result);
        }

        public Result<TEntry, ErrorResult> Update(TEntry item)
        {
            try
            {
                _context.ChangeTracker.Clear();
                _set.Attach(item).State = EntityState.Modified;
                var response = _set.Update(item);
                _context.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On update Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                return Result.Failure<TEntry, ErrorResult>(ErrorException.Exception<TEntry>(ex.Message));
            }
        }

        public async Task<Result<TEntry, ErrorResult>> AddAsync(TEntry item)
        {
            var validator = await _iValidator.ValidateAsync(item);

            if (!validator.IsValid)
                return ErrorValidation.Validation(validator.Errors);

            try
            {
                var response = await _set.AddAsync(item);
                await _context.SaveChangesAsync();
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On Add Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                return Result.Failure<TEntry, ErrorResult>(ErrorException.Exception<TEntry>(ex.Message));
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
                return Result.Failure<TEntry, ErrorResult>(ErrorException.Exception<TEntry>(ex.Message));
            }
        }
    }
}
