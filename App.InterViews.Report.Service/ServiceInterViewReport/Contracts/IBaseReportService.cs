using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IBaseReportService<TOut>
{
    Task<Result<IEnumerable<TOut>, ErrorResult>> GetAllAsync();
    Task<Result<TOut, ErrorResult>> GetByIdAsync(Guid id);
    Task<Result<TOut, ErrorResult>> AddAsync(TOut dto);
    Task<Result<TOut, ErrorResult>> DeleteAsync(Guid id);
    Task<Result<TOut, ErrorResult>> UpdateAsync(TOut dto);
}
