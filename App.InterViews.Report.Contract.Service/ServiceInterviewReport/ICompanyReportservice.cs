using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface ICompanyReportservice<TResultValidation>
    {
        IEnumerable<Company>? GetAllCompanies();
        Company? GetCompanyById(int idCompany);
        Task<Result<Company?, TResultValidation>> AddCompany(ServiceCompanyModel companyModel);
        Company? DeleteCompany(int idcompany);
    }
}
