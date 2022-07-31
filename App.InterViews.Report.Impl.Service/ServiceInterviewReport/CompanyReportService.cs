using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class CompanyReportService : ICompanyReportservice
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Company> _iRepositoryBaseCompany;

        public CompanyReportService(IRepositoryBase<Company> iRepositoryBaseCompany, IMapper mapper)
        {
            _mapper = mapper;
            _iRepositoryBaseCompany = iRepositoryBaseCompany;
        }

        public List<Company> GetAllCompanies()
        {
            var companies = _iRepositoryBaseCompany.GetAll();
            return companies.ToList();
        }

        public Company? AddInterView(ServiceCompanyModel companyModel)
        {
            try
            {
                var company = _mapper.Map<Company>(companyModel);
                return _iRepositoryBaseCompany.Add(company).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Company? DeleteCompany(int idcompany)
        {
            var company = _iRepositoryBaseCompany.GetById(idcompany);
            if (company != null)
            {
                var response = _iRepositoryBaseCompany.Delete(company);
                return response;
            }
            return null;
        }
    }
}
