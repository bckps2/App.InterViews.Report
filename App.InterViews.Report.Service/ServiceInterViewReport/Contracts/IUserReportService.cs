using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts
{
    public interface IUserReportService : IReportServiceBase<User, UserDto>
    {
    }
}
