using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyReportservice _iServiceCompany;

        public CompanyController(ICompanyReportservice iServiceCompany, IMapper mapper)
        {
            _iServiceCompany = iServiceCompany;
            _mapper = mapper;
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            return Ok(_iServiceCompany.GetAllCompanies());
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany(CompanyModel companyModel)
        {
            var company = _mapper.Map<ServiceCompanyModel>(companyModel);
            return Ok(_iServiceCompany.AddInterView(company));
        }

        [HttpDelete("DeleteCompany/{idCompany}")]
        public IActionResult DeleteCompany(int idCompany)
        {
            return Ok(_iServiceCompany.DeleteCompany(idCompany));
        }
    }
}
