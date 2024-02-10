﻿using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IUserReportService : IReportServiceBase<UserDto>
{
    Task<Result<List<UserDto>, ErrorResult>> GetByIds(ICollection<Guid> ids);
}
