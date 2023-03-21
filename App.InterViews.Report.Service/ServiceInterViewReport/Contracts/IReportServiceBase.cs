using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IReportServiceBase<TEntry, TOut>
{
    Result<IEnumerable<TOut>, ValidationResult> GetAll();
    Task<Result<TOut, ValidationResult>> GetById(int id);
    Task<Result<TOut, ValidationResult>> Add(TOut dto);
    Task<Result<TOut, ValidationResult>> Delete(int id);
}
