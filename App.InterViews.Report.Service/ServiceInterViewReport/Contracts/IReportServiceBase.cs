using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IReportServiceBase<TEntry, TOut>
{
    Result<IEnumerable<TOut>, ErrorResult> GetAll();
    Task<Result<TOut, ErrorResult>> GetById(int id);
    Task<Result<TOut, ErrorResult>> Add(TOut dto);
    Task<Result<TOut, ErrorResult>> Delete(int id);
}
