using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Contract.Service;
using CSharpFunctionalExtensions;
using FluentValidation;
using FluentValidation.Results;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryBase<T, DefaultValue> : IRepositoryBase<T, DefaultValue> where T : class where DefaultValue : ValidationResult
    {
        private readonly DbDataContext _context;
        private readonly DbSet<T> _set;
        private readonly IValidator<T> _iValidator;

        public RepositoryBase(DbDataContext context, IValidator<T> iValidator)
        {
            _context = context;
            _set = context.Set<T>();
            _iValidator = iValidator;
        }

        public T? GetById(int id)
        {
            return  _set.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _set.AsEnumerable();
        }

        public ActionResult<T> Update(T item)
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

        public async Task<Result<T, DefaultValue>> AddAsync(T item)
        {
            var validator = await _iValidator.ValidateAsync(item);

            if (!validator.IsValid)
                return (DefaultValue)validator;

            var response = await _set.AddAsync(item);
            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public T Delete(T item) 
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
