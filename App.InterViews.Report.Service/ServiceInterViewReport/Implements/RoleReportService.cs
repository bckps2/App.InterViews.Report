using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class RoleReportService : BaseReportService<Role, RoleDto>, IRoleReportService
{
    public RoleReportService(IRepositoryBase<Role> iRepositoryBase, IMapper mapper) : base(iRepositoryBase, mapper)
    {
    }
}
