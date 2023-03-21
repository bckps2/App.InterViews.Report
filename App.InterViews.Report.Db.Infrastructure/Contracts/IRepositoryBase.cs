using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface IRepositoryBase<TEntry>
{
    Task<Result<TEntry, ValidationResult>> AddAsync(TEntry item);
    Task<Result<TEntry, ValidationResult>> GetByIdAsync(int id);
    Result<IEnumerable<TEntry>, ValidationResult> GetAll();
    Result<TEntry, ValidationResult> Update(TEntry item);
    Result<TEntry, ValidationResult> Delete(TEntry item);
}
