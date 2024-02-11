using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IUserReportService : IBaseReportService<UserDto>
{
    Task<Result<UserDto, ErrorResult>> Update(UserDto dto);
    Task<Result<List<UserDto>, ErrorResult>> GetByIds(ICollection<Guid> ids);
}
