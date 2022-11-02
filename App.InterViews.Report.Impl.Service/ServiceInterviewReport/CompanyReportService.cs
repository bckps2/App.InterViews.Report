using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Db.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Extensions;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class CompanyReportService : ICompanyReportservice
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Company> _iRepositoryBaseCompany;
        private readonly DbDataContext _context;

        public CompanyReportService(IRepositoryBase<Company> iRepositoryBaseCompany, IMapper mapper, DbDataContext context)
        {
            _context = context;
            _mapper = mapper;
            _iRepositoryBaseCompany = iRepositoryBaseCompany;
        }

        public List<Company>? GetAllCompanies()
        {
            var companies = _context.Companies?.Include(c => c.Process).ThenInclude(c => c.Interviews).ToList();
            
            foreach (var company in companies)
            {
                foreach (var process in company.Process)
                {
                    process.Interviews.ToList().ForEach(c => c.SetNameInterViewers());
                }
            }

            return _context.Companies?.Include(c => c.Process).ThenInclude(c => c.Interviews).ToList();
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
