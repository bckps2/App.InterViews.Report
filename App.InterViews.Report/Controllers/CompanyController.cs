using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly ICompanyReportService _iServiceCompany;

    public CompanyController(ICompanyReportService iServiceCompany, IMapper mapper, IAutoMapperHttp iAutoMapperHttp)
    {
        _mapper = mapper;
        _iServiceCompany = iServiceCompany;
        _iAutoMapperHttp = iAutoMapperHttp;
    }

    [HttpGet("GetCompanyById/{idCompany}")]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.OK)]
    public async Task<IResult> GetCompanyById(Guid idCompany)
    {
        var result = await _iServiceCompany.GetById(idCompany);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetAllCompanies")]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), (int)HttpStatusCode.OK)]
    public IResult GetAllCompanies()
    {
        return _iAutoMapperHttp.Ok(_iServiceCompany.GetAll());
    }

    [HttpPost("AddCompany")]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), (int)HttpStatusCode.Created)]
    public async Task<IResult> AddCompany(CompanyModel companyModel)
    {
        var company = _mapper.Map<CompanyDto>(companyModel);
        var result = await _iServiceCompany.Add(company);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("DeleteCompany/{idCompany}")]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.OK)]
    public async Task<IResult> DeleteCompany(Guid idCompany)
    {
        var result = await _iServiceCompany.Delete(idCompany);
        return _iAutoMapperHttp.Ok(result);
    }
}
