using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IInterViewReportService<TEntry> : IReportServiceBase<TEntry, InterviewDto>
{
    Task<Result<InterviewDto, ValidationResult>> Update(InterviewDto dto);
}
