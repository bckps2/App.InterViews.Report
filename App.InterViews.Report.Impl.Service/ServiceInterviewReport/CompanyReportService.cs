using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Library.Extensions;
using FluentValidation;
using FluentValidation.Results;
using CSharpFunctionalExtensions;
using App.InterViews.Report.Db.Infrastructure;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class CompanyReportService<TValidation> : ICompanyReportservice<TValidation> where TValidation : ValidationResult
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Company?, TValidation> _iRepositoryBaseCompany;

        public CompanyReportService(IRepositoryBase<Company?, TValidation> iRepositoryBaseCompany, IMapper mapper)
        {
            _mapper = mapper;
            _iRepositoryBaseCompany = iRepositoryBaseCompany;
        }

        public Company? GetCompanyById(int idCompany)
        {
            var company = _iRepositoryBaseCompany.GetById(idCompany);

            foreach (var process in company.Process)
            {
                process.Interviews.ToList().ForEach(c => c.SetNameInterViewers());
            }

            return company;
        }

        public IEnumerable<Company>? GetAllCompanies()
        {
            var companies = _iRepositoryBaseCompany.GetAll();
            
            foreach (var company in companies)
            {
                foreach (var process in company.Process)
                {
                    process.Interviews.ToList().ForEach(c => c.SetNameInterViewers());
                }
            }

            return companies;
        }

        public async Task<Result<Company?, TValidation>> AddCompany(ServiceCompanyModel companyModel)
        {
            var company = _mapper.Map<Company?>(companyModel);
            return await _iRepositoryBaseCompany.AddAsync(company);
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
