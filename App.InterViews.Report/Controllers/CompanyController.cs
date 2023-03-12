using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Http;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Models;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyReportservice<Company, ValidationResult> _iServiceCompany;
        private readonly IAutoMapperHttp _iAutoMapperHttp;

        public CompanyController(ICompanyReportservice<Company, ValidationResult> iServiceCompany, IMapper mapper, IAutoMapperHttp iAutoMapperHttp)
        {
            _iServiceCompany = iServiceCompany;
            _mapper = mapper;
            _iAutoMapperHttp = iAutoMapperHttp;
        }

        [HttpGet("GetCompanyById/{idCompany}")]
        public async Task<IResult> GetCompanyById(int idCompany)
        {
            var result = await _iServiceCompany.GetCompanyById(idCompany);
            return _iAutoMapperHttp.Ok(result);
        }

        [HttpGet("GetAllCompanies")]
        public IResult GetAllCompanies()
        {
            return _iAutoMapperHttp.Ok(_iServiceCompany.GetAllCompanies());
        }
            
        [HttpPost("AddCompany")]
        public async Task<IResult> AddCompany(CompanyModel companyModel)
        {
            var company = _mapper.Map<ServiceCompanyDto>(companyModel);
            var result = await _iServiceCompany.AddCompany(company);
            return _iAutoMapperHttp.Ok(result);
        }

        //[HttpDelete("DeleteCompany/{idCompany}")]
        //public IActionResult DeleteCompany(int idCompany)
        //{
        //    return Ok(_iServiceCompany.DeleteCompany(idCompany));
        //}
    }
}
