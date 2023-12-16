using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface IRepositoryBase<TEntry>
{
    Task<Result<TEntry, ErrorResult>> AddAsync(TEntry item);
    Task<Result<TEntry, ErrorResult>> GetByIdAsync(int id);
    Result<IEnumerable<TEntry>, ErrorResult> GetAll();
    Result<TEntry, ErrorResult> Update(TEntry item);
    Result<TEntry, ErrorResult> Delete(TEntry item);
}
