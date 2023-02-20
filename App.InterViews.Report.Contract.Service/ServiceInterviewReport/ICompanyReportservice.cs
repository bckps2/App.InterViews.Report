using App.InterViews.Report.Contract.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface ICompanyReportservice<TEntry, TResultValidation>
    {
        Task<Result<ServiceCompanyDto, TResultValidation>> AddCompany(ServiceCompanyDto companyModel);
        Result<IEnumerable<ServiceCompanyDto>, TResultValidation> GetAllCompanies();
        Task<Result<ServiceCompanyDto, TResultValidation>> GetCompanyById(int idCompany);
        //Company? DeleteCompany(int idcompany);
    }
}
