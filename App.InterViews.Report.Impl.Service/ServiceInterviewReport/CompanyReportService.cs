using AutoMapper;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using FluentValidation.Results;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class CompanyReportService<TEntry, TValidation> : ICompanyReportservice<TEntry, TValidation> where TValidation : ValidationResult
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<TEntry, TValidation> _iRepositoryBaseCompany;

        public CompanyReportService(IRepositoryBase<TEntry, TValidation> iRepositoryBaseCompany, IMapper mapper)
        {
            _mapper = mapper;
            _iRepositoryBaseCompany = iRepositoryBaseCompany;
        }

        public async Task<Result<ServiceCompanyDto, TValidation>> GetCompanyById(int idCompany)
        {
            var value = await _iRepositoryBaseCompany.GetById(idCompany);

            return value.Map(val =>
            {
                return _mapper.Map<ServiceCompanyDto>(value.Value);
            });
        }

        public Result<IEnumerable<ServiceCompanyDto>, TValidation> GetAllCompanies()
        {
            var companies = _iRepositoryBaseCompany.GetAll();

            return companies.Map(value =>
            {
                return _mapper.Map<IEnumerable<ServiceCompanyDto>>(value);
            });
        }

        public async Task<Result<ServiceCompanyDto, TValidation>> AddCompany(ServiceCompanyDto companyModel)
        {
            var company = _mapper.Map<TEntry>(companyModel);
            var result = await _iRepositoryBaseCompany.AddAsync(company);
            
            return result.Map(val => 
            { 
                return _mapper.Map<ServiceCompanyDto>(val); 
            });
        }

        //public Company DeleteCompany(int idcompany)
        //{
        //    var company = _iRepositoryBaseCompany.GetById(idcompany);
        //    if (company != null)
        //    {
        //        var response = _iRepositoryBaseCompany.Delete(company);
        //        return response;
        //    }
        //    return null;
        //}
    }
}
