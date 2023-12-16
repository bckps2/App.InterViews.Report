using App.InterViews.Report.Service.Dtos;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

public interface ICompanyReportService<TEntry> : IReportServiceBase<TEntry, CompanyDto>
{
}
