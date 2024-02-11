using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using System.Linq.Expressions;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface IRepositoryBase<TEntry>
{
    Task<Result<TEntry, ErrorResult>> AddAsync(TEntry item);
    Task<Result<TEntry, ErrorResult>> GetByIdAsync(Guid id);
    Task<Result<IEnumerable<TEntry>, ErrorResult>> GetAllAsync();
    Result<TEntry, ErrorResult> Update(TEntry item);
    Task<Result<TEntry, ErrorResult>> DeleteAsync(Guid id);
    Task<Result<IEnumerable<TEntry>, ErrorResult>> GetEntitiesByFilter(Expression<Func<TEntry, bool>> expression);
}
