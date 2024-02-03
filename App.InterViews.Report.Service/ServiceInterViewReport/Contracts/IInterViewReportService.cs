﻿using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IInterViewReportService : IReportServiceBase<InterView, InterviewDto>
{
    Task<Result<InterviewDto, ErrorResult>> Update(InterviewDto dto);
    Result<IEnumerable<InterviewDto>, ErrorResult> GetAllByIdProcess(int idProcess);
}