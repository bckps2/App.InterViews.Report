using App.InterViews.Report.Contract.Service.Dtos;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface ICompanyReportservice<TEntry, TValidation>
    {
        Task<Result<ServiceCompanyDto, TValidation>> AddCompany(ServiceCompanyDto companyModel);
        Result<IEnumerable<ServiceCompanyDto>, TValidation> GetAllCompanies();
        Task<Result<ServiceCompanyDto, TValidation>> GetCompanyById(int idCompany);
        //Company? DeleteCompany(int idcompany);
    }
}
