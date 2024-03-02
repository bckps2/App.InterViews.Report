using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Service.Dtos.User;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface IUserReportService : IBaseReportService<UserDto>
{
    new Task<Result<UserCompanyDto, ErrorResult>> GetByIdAsync(Guid userId);
    new Task<Result<IEnumerable<UserCompanyDto>, ErrorResult>> GetAllAsync();
    Task<Result<IEnumerable<UserDto>, ErrorResult>> GetAllByCompanyIdAsync(Guid companyId);
}
