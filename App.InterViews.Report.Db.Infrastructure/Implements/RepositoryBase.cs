using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Db.Infrastructure.Context;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbDataContext _context;
        private readonly DbSet<T> _set;

        public RepositoryBase(DbDataContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task<ActionResult<T?>> GetById(int id)
        {
            return await _set.FindAsync(id);
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
                _context.SaveChanges();
                Log.Information("{Message}-{IdType}-{CustomType}", $"Processing Data in Repository Base {item.GetType().Name} and Item: {item}", id, item.GetType().Name);
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Error($"On Add Object {item.GetType()}, Message Error : {ex.Message}, Stacktrace: {ex.InnerException}");
                throw;
            }
        }

        public ActionResult<T> Add(T item)
        {
            try
            {
                var response = _set.Add(item);
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
