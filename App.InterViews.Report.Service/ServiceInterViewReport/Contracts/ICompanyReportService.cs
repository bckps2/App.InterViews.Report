using App.InterViews.Report.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Contracts
{
    public interface ICompanyReportService<TEntry> : IReportServiceBase<TEntry, CompanyDto>
    {

    }
}
