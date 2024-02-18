using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos.Company;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController
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
    public async Task<IActionResult> GetCompanyById(Guid idCompany)
    {
        var result = await _iServiceCompany.GetCompanyByIdAsync(idCompany);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetCompaniesByUserId/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCompaniesByUserId(Guid userId)
    {
        var result = await _iServiceCompany.GetAllCompaniesByUser(userId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetAllCompanies")]
    [ProducesResponseType(typeof(IEnumerable<CompanyUserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllCompanies()
    {
        var result = await _iServiceCompany.GetAllCompanies();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost("AddCompany")]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddCompany(CompanyModel companyModel)
    {
        var company = _mapper.Map<CompanyDto>(companyModel);
        var result = await _iServiceCompany.Add(company);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpDelete("DeleteCompany/{idCompany}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteCompany(Guid idCompany)
    {
        var result = await _iServiceCompany.Delete(idCompany);
        return _iAutoMapperHttp.NoContent(result);
    }
}
