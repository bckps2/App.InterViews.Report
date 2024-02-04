using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IReportServiceBase<TEntry, TOut>
{
    Result<IEnumerable<TOut>, ErrorResult> GetAll();
    Task<Result<TOut, ErrorResult>> GetById(Guid id);
    Task<Result<TOut, ErrorResult>> Add(TOut dto);
    Task<Result<TOut, ErrorResult>> Delete(Guid id);
}
