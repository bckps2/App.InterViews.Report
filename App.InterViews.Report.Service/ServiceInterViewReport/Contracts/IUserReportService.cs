using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos.User;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IUserReportService : IBaseReportService<UserDto>
{
    Task<Result<UserDto, ErrorResult>> Update(UserDto dto);
    Task<Result<IEnumerable<UserCompanyDto>, ErrorResult>> GetAllUsers();
    Task<Result<UserCompanyDto, ErrorResult>> GetUserByIdAsync(Guid userId);
    Task<Result<IEnumerable<UserDto>, ErrorResult>> GetUsersByCompanyIdAsync(Guid companyId);
}
