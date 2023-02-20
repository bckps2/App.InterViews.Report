using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Db.Infrastructure.Context;
using CSharpFunctionalExtensions;
using FluentValidation;
using FluentValidation.Results;
using App.InterViews.Report.CrossCutting.Helper;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryBase<TEntry, DefaultValue> : IRepositoryBase<TEntry, DefaultValue> where TEntry : class where DefaultValue : ValidationResult
    {
        private readonly DbDataContext _context;
        private readonly DbSet<TEntry> _set;
        private readonly IValidator<TEntry> _iValidator;

        public RepositoryBase(DbDataContext context, IValidator<TEntry> iValidator)
        {
            _context = context;
            _set = context.Set<TEntry>();
            _iValidator = iValidator;
        }

        public async Task<Result<TEntry, DefaultValue>> GetById(int id)
        {
            var result = await _set.FindAsync(id);
            
            if(result is null) 
            {
                return Result.Failure<TEntry, DefaultValue>((DefaultValue)ErrorResult.NotFound<TEntry>());
            }

            return result;
        }

        public Result<IEnumerable<TEntry>, DefaultValue> GetAll()
        {
            var result = _set.AsEnumerable();
            
            if (result is null || !result.Any())
            {
                return Result.Failure<IEnumerable<TEntry>,DefaultValue>((DefaultValue)ErrorResult.NotFound<TEntry>());
            }

            return Result.Success<IEnumerable<TEntry>, DefaultValue>(result);
        }

        public ActionResult<TEntry> Update(TEntry item)
        {
            try
            {
                var response = _set.Update(item);
                var id = (item.GetType().Name);
                Log.Information("{Message}-{IdType}-{CustomType}", $"Processing Data in Repository Base {item.GetType().Name} and Item: {item}", id, item.GetType().Name);
                _context.SaveChanges();                
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On Add Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                throw;
            }
        }

        public async Task<Result<TEntry, DefaultValue>> AddAsync(TEntry item)
        {
            var validator = await _iValidator.ValidateAsync(item);

            if (!validator.IsValid)
                return (DefaultValue)validator;

            var response = await _set.AddAsync(item);
            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public TEntry Delete(TEntry item) 
        {
            try
            {
                var response = _set.Remove(item);
                var id = (item.GetType().Name);
                Log.Information("{Message}-{IdType}-{CustomType}", $"Processing Data in Repository Base {item.GetType().Name} and Item: {item}", id, item.GetType().Name);
                _context.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On Add Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                throw;
            }
        }
    }
}
