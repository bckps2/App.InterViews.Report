using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyReportservice<ValidationResult> _iServiceCompany;

        public CompanyController(ICompanyReportservice<ValidationResult> iServiceCompany, IMapper mapper)
        {
            _iServiceCompany = iServiceCompany;
            _mapper = mapper;
        }

        [HttpGet("GetCompanyById/{idCompany}")]
        public IActionResult GetCompanyById(int idCompany)
        {
            return Ok(_iServiceCompany.GetCompanyById(idCompany));
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            return Ok(_iServiceCompany.GetAllCompanies());
        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompany(CompanyModel companyModel)
        {
            var company = _mapper.Map<ServiceCompanyModel>(companyModel);
            var result = await _iServiceCompany.AddCompany(company);

            if (result.IsFailure) 
            {
                return BadRequest(result.Error.Errors[0].ErrorMessage);
            }

            return Ok(result);
        }

        [HttpDelete("DeleteCompany/{idCompany}")]
        public IActionResult DeleteCompany(int idCompany)
        {
            return Ok(_iServiceCompany.DeleteCompany(idCompany));
        }
    }
}
