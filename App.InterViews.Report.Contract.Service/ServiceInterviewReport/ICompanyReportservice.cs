using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface ICompanyReportservice
    {
        List<Company>? GetAllCompanies();
        Company? GetCompanyById(int idCompany);
        Company? AddInterView(ServiceCompanyModel companyModel);
        Company? DeleteCompany(int idcompany);
    }
}
