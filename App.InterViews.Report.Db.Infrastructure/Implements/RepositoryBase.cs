using Serilog;
using FluentValidation;
using FluentValidation.Results;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<Result<TEntry, ValidationResult>> GetByIdAsync(int id)
        {
            var result = await _set.FindAsync(id);
            if(result is null) 
            {
                Log.Error($"On Get Object By Id {nameof(TEntry).GetType()}, Message Error : item Not found");
                return Result.Failure<TEntry, ValidationResult>(ErrorResult.NotFound<TEntry>());
            }

            return result;
        }

        public Result<IEnumerable<TEntry>, ValidationResult> GetAll()
        {
            var result = _set.AsEnumerable();
            
            if (result is null || !result.Any())
            {
                return Result.Failure<IEnumerable<TEntry>, ValidationResult>(ErrorResult.NotFound<TEntry>());
            }
            Log.Error($"On Get All Objects {nameof(TEntry).GetType()}, Message Error : items Not found");
            return Result.Success<IEnumerable<TEntry>, ValidationResult>(result);
        }

        public Result<TEntry, ValidationResult> Update(TEntry item)
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
                return Result.Failure<TEntry, ValidationResult>(ErrorResult.ExceptionError<TEntry>(ex.Message));
            }
        }

        public async Task<Result<TEntry, ValidationResult>> AddAsync(TEntry item)
        {
            var validator = await _iValidator.ValidateAsync(item);

            if (!validator.IsValid)
                return validator;

            try
            {
                var response = await _set.AddAsync(item);
                await _context.SaveChangesAsync();
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On Add Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                return Result.Failure<TEntry, ValidationResult>(ErrorResult.ExceptionError<TEntry>(ex.Message));
            }
        }

        public Result<TEntry, ValidationResult> Delete(TEntry item) 
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
                return Result.Failure<TEntry, ValidationResult>(ErrorResult.ExceptionError<TEntry>(ex.Message));
            }
        }
    }
}
